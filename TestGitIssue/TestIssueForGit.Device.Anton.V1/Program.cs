using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace TestIssueForGit.Device.Anton.V1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            X509Certificate2 x509Certificate = Helper.LoadProvisioningCertificate(ConfigurationManager.AppSettings["CertPassword"]);
            var security = new SecurityProviderX509Certificate(x509Certificate);

            IAuthenticationMethod auth = new DeviceAuthenticationWithX509Certificate(
                security.GetRegistrationID(),
                x509Certificate);

            var deviceClient = DeviceClient.Create(Helper.IotHubHostName, auth, TransportType.Mqtt);

            await deviceClient.OpenAsync();

            await deviceClient.SetReceiveMessageHandlerAsync(mHandler, deviceClient);

            await Task.Delay(-1);
        }

        private static Task mHandler(Message message, object deviceClient)
        {
            var stream = message.GetBodyStream();

            Console.WriteLine(JsonConvert.SerializeObject(
            new
            {
                Body = "",
                message.Properties,
                message.MessageId,
                message.To,
                message.CorrelationId
            }, Newtonsoft.Json.Formatting.Indented));

            return ((DeviceClient)deviceClient).CompleteAsync(message);
        }
    }
}