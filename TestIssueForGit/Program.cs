using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Provisioning.Client;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace TestIssueForGit
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            X509Certificate2 x509Certificate = Helper.LoadProvisioningCertificate();
            var security = new AuthenticationProviderX509(x509Certificate);

            var provClient = new ProvisioningDeviceClient(
                "global.azure-devices-provisioning.net",
                 Helper.IdScope,
                security,
                options: new ProvisioningClientOptions(new ProvisioningClientMqttSettings()));

            var result = await provClient.RegisterAsync();

            IAuthenticationMethod auth = new ClientAuthenticationWithX509Certificate(x509Certificate, security.GetRegistrationId());

            var deviceClient = new IotHubDeviceClient(result.AssignedHub, auth, new IotHubClientOptions(new IotHubClientMqttSettings()));
            deviceClient.ConnectionStatusChangeCallback = (ConnectionStatusInfo info) =>
            {
                Console.WriteLine($"Device Status {info.Status}; Change reason: {info.ChangeReason}; Recommended action {info.RecommendedAction}.");
            };
            await deviceClient!.OpenAsync(CancellationToken.None);


            //await deviceClient.SetIncomingMessageCallbackAsync(
            //    async (IncomingMessage message) =>
            //    {
            //        message.TryGetPayload<string>(out var payload);

            //        Console.WriteLine(JsonConvert.SerializeObject(
            //        new
            //        {
            //            Body = payload,
            //            message.Properties,
            //            message.MessageId,
            //            message.To,
            //            message.CorrelationId
            //        }, Newtonsoft.Json.Formatting.Indented));


            //        return MessageAcknowledgement.Complete;
            //    }).ConfigureAwait(false);

            await Task.Delay(-1);
        }
    }
}