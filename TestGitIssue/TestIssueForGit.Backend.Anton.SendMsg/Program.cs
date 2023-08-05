using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace TestIssueForGit.Backend.Anton
{
    internal class Program
    {
        private static IotHubServiceClient _serviceClient;

        async static Task Main(string[] args)
        {
            _serviceClient = new IotHubServiceClient(ConfigurationManager.AppSettings["IoTHubConnectionString"]);

            while (true)
            {
                await Console.Out.WriteLineAsync("Press Enter to send message... ");
                Console.ReadKey();
                await SendC2dMessagesAsync(CancellationToken.None);
            }
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