using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Provisioning.Client;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace TestIssueForGit.Device.Anton
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            X509Certificate2 x509Certificate = Helper.LoadProvisioningCertificate();
            var security = new AuthenticationProviderX509(x509Certificate);

            var registrationId = security.GetRegistrationId();

            IAuthenticationMethod auth = new ClientAuthenticationWithX509Certificate(x509Certificate, registrationId);

            var deviceClient = new IotHubDeviceClient(Helper.IotHubHostName, auth, new IotHubClientOptions(new IotHubClientMqttSettings()));

            deviceClient.ConnectionStatusChangeCallback = (info) =>
            {
                Console.WriteLine($"Device Status {info.Status}; Change reason: {info.ChangeReason}; Recommended action {info.RecommendedAction}.");
            };
            await deviceClient!.OpenAsync(CancellationToken.None);

            TaskCompletionSource taskCompletionSource = new TaskCompletionSource();

            await deviceClient.SetIncomingMessageCallbackAsync(
                async (message) =>
                {
                    try
                    {
                        message.TryGetPayload<string>(out var payload);

                        Console.WriteLine(JsonConvert.SerializeObject(
                        new
                        {
                            Body = payload,
                            message.Properties,
                            message.MessageId,
                            message.To,
                            message.CorrelationId
                        }, Formatting.Indented));
                        return MessageAcknowledgement.Complete;
                    }
                    finally
                    {
                        taskCompletionSource.SetResult();
                    }
                }).ConfigureAwait(false);

            //await taskCompletionSource.Task;

            //await deviceClient.SetIncomingMessageCallbackAsync(null);

            await Task.Delay(-1);
        }

        private static async Task AddDeviceIdentityFromEnrollment()
        {
            X509Certificate2 x509Certificate = Helper.LoadProvisioningCertificate();
            var security = new AuthenticationProviderX509(x509Certificate);

            var provClient = new ProvisioningDeviceClient(
                Helper.GlobalDeviceEndpoint,
                 Helper.IdScope,
                security,
                options: new ProvisioningClientOptions(new ProvisioningClientMqttSettings()));

            var result = await provClient.RegisterAsync();

            var registrationId = security.GetRegistrationId();
            IAuthenticationMethod auth = new ClientAuthenticationWithX509Certificate(x509Certificate, registrationId);

            var deviceClient = new IotHubDeviceClient(result.AssignedHub, auth, new IotHubClientOptions(new IotHubClientMqttSettings()));
            deviceClient.ConnectionStatusChangeCallback = (info) =>
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

        async static Task AddDeviceIdentityDirectly()
        {
            X509Certificate2 x509Certificate = Helper.LoadProvisioningCertificate();
            var security = new AuthenticationProviderX509(x509Certificate);

            var registrationId = security.GetRegistrationId();

            IAuthenticationMethod auth = new ClientAuthenticationWithX509Certificate(x509Certificate, registrationId);

            var deviceClient = new IotHubDeviceClient(Helper.IotHubHostName, auth, new IotHubClientOptions(new IotHubClientMqttSettings()));

            deviceClient.ConnectionStatusChangeCallback = (info) =>
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