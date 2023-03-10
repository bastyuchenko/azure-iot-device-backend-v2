using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Provisioning.Client;
using Microsoft.Azure.Devices.Provisioning.Client.Transport;
using Microsoft.Azure.Devices.Shared;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TestIssueForGit
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            X509Certificate2 x509Certificate = Helper.LoadProvisioningCertificate();
            var security = new AuthenticationProviderX509(x509Certificate);
            var provClient = new  ProvisioningDeviceClient(
                "global.azure-devices-provisioning.net",
                Helper.IdScope,
                security,
                options: new ProvisioningClientOptions(new ProvisioningClientMqttSettings()));

            var result = await provClient.RegisterAsync();

            IAuthenticationMethod auth = new ClientAuthenticationWithX509Certificate(
                x509Certificate,
                security.GetRegistrationId());


            var deviceClient = new IotHubDeviceClient(result.AssignedHub, auth, new IotHubClientOptions(new IotHubClientMqttSettings()));

            await deviceClient.SetIncomingMessageCallbackAsync(
                async (IncomingMessage messageC2D) =>
                {
                    try
                    {

                        messageC2D.TryGetPayload<string>(out string messageC2DText);
                        var messageD2C = new TelemetryMessage(Encoding.UTF8.GetBytes(messageC2DText + "_ToCloud"));
                        await deviceClient.SendTelemetryAsync(messageD2C);

                        return MessageAcknowledgement.Complete;
                    }
                    catch (Exception ex)
                    {
                        return MessageAcknowledgement.Abandon;
                        throw;
                    }
                }, CancellationToken.None);

            await Task.Delay(-1);
        }

        private static Task<MessageAcknowledgement> dsdcsdcsdcscd(IncomingMessage arg)
        {
            throw new NotImplementedException();
        }
    }
}