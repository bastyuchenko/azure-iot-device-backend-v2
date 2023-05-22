using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace IoT.Backend.Wpf
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private static IotHubServiceClient _serviceClient;

        private Parameters _parameters;

        private EventProcessorClient processor;

        public ServiceWindow()
        {
            _parameters = new Parameters();

            var options = new IotHubServiceClientOptions()
            {
                //                SdkAssignsMessageId = SdkAssignsMessageId.WhenUnset
            };

            _serviceClient = (new IotHubServiceClient(_parameters.IoTHubConnectionString, options));

            InitializeComponent();
            tbCorrelationId.Text = Guid.NewGuid().ToString("D");
        }


        private async void btnStartReceiving_Click(object sender, RoutedEventArgs e)
        {
            // Either the connection string must be supplied, or the set of endpoint, name, and shared access key must be.
            if (string.IsNullOrWhiteSpace(_parameters.EventHubConnectionString)) MessageBox.Show("error");

            Log("IoT Hub Quickstarts - Read device to cloud messages. Ctrl-C to exit.\r\n");

            var storageClient = new BlobContainerClient(_parameters.BlobStorageConnectionString, "event-hub-checkpoints");
            processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName,
                _parameters.EventHubConnectionString);

            processor.ProcessEventAsync += ProcessEventHandler;
            processor.ProcessErrorAsync += ProcessErrorHandler;

            await processor.StartProcessingAsync();
        }

        private async void btnStopReceiving_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await processor.StopProcessingAsync();
            }
            finally
            {
                // To prevent leaks, the handlers should be removed when processing is complete.
                processor.ProcessEventAsync -= ProcessEventHandler;
                processor.ProcessErrorAsync -= ProcessErrorHandler;
            }
        }

        private async Task ProcessEventHandler(ProcessEventArgs partitionEvent)
        {
            Log($"Message received on partition {partitionEvent.Partition.PartitionId}:");

            var EventBody = Encoding.UTF8.GetString(partitionEvent.Data.EventBody.ToArray());
            tbReceivedMsg.Text += (JsonConvert.SerializeObject(
                new
                {
                    EventBody,
                    partitionEvent.Data.Properties,
                    partitionEvent.Data.SystemProperties,
                }, Newtonsoft.Json.Formatting.Indented));

            // Update checkpoint in the blob storage so that the app receives only new events the next time it's run
            await partitionEvent.UpdateCheckpointAsync(partitionEvent.CancellationToken);
        }

        private Task ProcessErrorHandler(ProcessErrorEventArgs arg)
        {
            Log($"ERROR: {arg.Exception.Message}");
            return Task.CompletedTask;
        }

        private async void btnSendToDevice_Click(object sender, RoutedEventArgs e)
        {
            _serviceClient = new IotHubServiceClient(_parameters.IoTHubConnectionString);
            var sendTask = SendC2dMessagesAsync(CancellationToken.None);
            var receiveTask = ReceiveMessageFeedbacksAsync(CancellationToken.None);

            await Task.WhenAll(sendTask, receiveTask);
        }

        private async Task ReceiveMessageFeedbacksAsync(CancellationToken token)
        {
            // It is important to note that receiver only gets feedback messages when the device is actively running and acting on messages.
            Log("Starting to listen to feedback messages");

            _serviceClient.MessageFeedback.MessageFeedbackProcessor =
            (FeedbackBatch batch) =>
            {
                Log("New Feedback received:");
                Log(JsonConvert.SerializeObject(
                    new
                    {
                        batch.EnqueuedOnUtc,
                        batch.Records
                    }, Newtonsoft.Json.Formatting.Indented));
                return Task.FromResult(AcknowledgementType.Complete);
            };
        }

        private async Task SendC2dMessagesAsync(CancellationToken cancellationToken)
        {
            var messageId = Guid.NewGuid().ToString("D");
            tbMessageId.Text = messageId;
            var message = new OutgoingMessage(Encoding.ASCII.GetBytes(tbSentMsg.Text))
            {
                MessageId = messageId,
                CorrelationId = tbCorrelationId.Text,
                // An acknowledgment is sent on delivery success or failure.
                Ack = DeliveryAcknowledgement.Full
            };
            message.Properties.Add("custom-prop-device-id", tbDeviceId.Text);

            Log($"Sending C2D message with Id {message.MessageId} to {tbDeviceId.Text}.");

            try
            {
                await _serviceClient.Messages.OpenAsync();
                await _serviceClient.Messages.SendAsync(tbDeviceId.Text, message, CancellationToken.None);
                Log($"Sent message with Id {message.MessageId} to {tbDeviceId.Text}.");
            }
            catch (Exception e)
            {
                Log($"Transient Exception occurred, will retry: {e}");
            }
        }

        internal class Parameters
        {
            public string DeviceId = "iothubx509device1";

            public string EventHubConnectionString = ConfigurationSettings.AppSettings["EventHubConnectionString"];
            public string IoTHubConnectionString = ConfigurationSettings.AppSettings["IoTHubConnectionString"];
            public string BlobStorageConnectionString = ConfigurationSettings.AppSettings["BlobStorageConnectionString"];
        }

        private async void btnWDesired_Click(object sender, RoutedEventArgs e)
        {
            var twin = await _serviceClient.Twins.GetAsync(_parameters.DeviceId);

            var patch =
                $@"{{
                    properties: {{
                        desired: {{
                          myCustomKey: '{tbDTdesired.Text}'
                        }}
                    }}
                }}";

            await _serviceClient.Twins.UpdateAsync(twin.DeviceId, twin, false);
        }

        private async void btnReadDT_Click(object sender, RoutedEventArgs e)
        {
            var twin = await _serviceClient.Twins.GetAsync(_parameters.DeviceId);
            tbDTRead.Text = twin.ToString();//.ToJson(Formatting.Indented);
            Log("Device Twin content was read");
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            lbStatus.Text = "";
        }

        private async void btnSendRequest_DirectMethod_Click(object sender, RoutedEventArgs e)
        {
            var methodInvocation = new DirectMethodServiceRequest(tbDirectMethodName.Text)
            {
                ResponseTimeout = TimeSpan.FromSeconds(30),
            };
            methodInvocation.Payload = tbDirectMethodPayload.Text;

            MessageBox.Show($"Invoking direct method for device: {tbDeviceId.Text}");

            // Invoke the direct method asynchronously and get the response from the simulated device.
            DirectMethodClientResponse response = await _serviceClient.DirectMethods.InvokeAsync(tbDeviceId.Text, methodInvocation);

            MessageBox.Show($"Response status: {response.Status}, payload:\n\t{response.PayloadAsString}");
        }

        private async void btnStartReceiveNotification_Click(object sender, RoutedEventArgs e)
        {
            _serviceClient.FileUploadNotifications.FileUploadNotificationProcessor = (FileUploadNotification fileUploadNotification) =>
            {

                Log(JsonConvert.SerializeObject(fileUploadNotification));
                return Task.FromResult(AcknowledgementType.Complete);
            };

            Log("\nReceiving file upload notification from service");

            await _serviceClient.FileUploadNotifications.OpenAsync(CancellationToken.None);
        }

        private async void btnStopReceiveNotification_Click(object sender, RoutedEventArgs e)
        {
            await _serviceClient.FileUploadNotifications.CloseAsync();
            Log("\nStop receiving file upload notification from service");
        }

        private void Log(string text)
        {
            this.Dispatcher.Invoke(() =>
            {
                lbStatus.Text += ("\r\n" + text);
            });
        }
    }
}
