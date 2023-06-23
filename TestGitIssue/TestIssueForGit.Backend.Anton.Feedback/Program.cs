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
            var iotHub = ConfigurationManager.AppSettings["IoTHubConnectionString"];
            _serviceClient = new IotHubServiceClient(iotHub);

            await ReceiveMessageFeedbacksAsync(CancellationToken.None);
            await Console.Out.WriteLineAsync("feedback listener started");

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
    }
}