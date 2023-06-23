using Microsoft.Azure.Devices;
using System.Configuration;
using System.Data;

namespace TestCreateDeviceIdentity.Anton
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var iotHubServiceClient = new IotHubServiceClient(ConfigurationManager.AppSettings["IoTHubConnectionString"]);

            var certificate = Helper.LoadProvisioningCertificate();

            var device = new Device(Helper.DeviceId)
            {
                Authentication = new AuthenticationMechanism()
                {
                    Type = ClientAuthenticationType.SelfSigned,
                    X509Thumbprint = new X509Thumbprint()
                    {
                        PrimaryThumbprint = certificate.Thumbprint,
                        SecondaryThumbprint = certificate.Thumbprint
                    }
                }
            };

            device.Status = ClientStatus.Enabled;

            await iotHubServiceClient.Devices.CreateAsync(device);
        }
    }
}