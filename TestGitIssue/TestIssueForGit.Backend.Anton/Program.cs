using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System.Configuration;

namespace TestIssueForGit.Backend.Anton
{
    internal class Program
    {
        private static IotHubServiceClient _serviceClient;

        async static Task Main(string[] args)
        {
            _serviceClient = new IotHubServiceClient(ConfigurationManager.AppSettings["IoTHubConnectionString"]);

            await ReceiveMessageFeedbacksAsync(CancellationToken.None);
            await SendC2dMessagesAsync(CancellationToken.None);

            await Task.Delay(-1);
        }

        private static async Task ReceiveMessageFeedbacksAsync(CancellationToken token)
        {
            // It is important to note that receiver only gets feedback messages when the device is actively running and acting on messages.

            _serviceClient.MessageFeedback.MessageFeedbackProcessor =
            (FeedbackBatch batch) =>
            {
                Console.WriteLine("New Feedback received:");
                Console.WriteLine(JsonConvert.SerializeObject(
                    new
                    {
                        batch.EnqueuedOnUtc,
                        batch.Records
                    }, Formatting.Indented));
                return Task.FromResult(AcknowledgementType.Complete);
            };
            await _serviceClient.MessageFeedback.OpenAsync(token);
        }

        private static async Task SendC2dMessagesAsync(CancellationToken cancellationToken)
        {
            var messageId = Guid.NewGuid().ToString("D");
            var correlationId = Guid.NewGuid().ToString("D");
            await Console.Out.WriteLineAsync($"MessageId: {messageId};");
            var message = new OutgoingMessage("test message")
            {
                MessageId = messageId,
                CorrelationId = correlationId,
                // An acknowledgment is sent on delivery success or failure.
                Ack = DeliveryAcknowledgement.Full
            };
            message.Properties.Add("custom-prop-device-id", Helper.DeviceId);

            Console.WriteLine($"Sending C2D message with Id {message.MessageId} to {Helper.DeviceId}.");

            try
            {
                await _serviceClient.Messages.OpenAsync();
                await _serviceClient.Messages.SendAsync(Helper.DeviceId, message, CancellationToken.None);
                Console.WriteLine($"Sent message with Id {message.MessageId} to {Helper.DeviceId}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Transient Exception occurred, will retry: {e}");
            }
        }
    }
}