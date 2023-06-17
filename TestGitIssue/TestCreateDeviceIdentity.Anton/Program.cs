using Microsoft.Azure.Devices;
using System.Configuration;

namespace TestCreateDeviceIdentity.Anton
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var iotHubServiceClient = new IotHubServiceClient(ConfigurationManager.AppSettings["IoTHubConnectionString"]);

            var device = new Device(Helper.DeviceId);

            var certificate = Helper.LoadProvisioningCertificate();
            device.Authentication = new AuthenticationMechanism()
            {
                X509Thumbprint = new X509Thumbprint()
                {
                    PrimaryThumbprint = certificate.Thumbprint,
                    SecondaryThumbprint = certificate.Thumbprint
                }
            };

            await iotHubServiceClient.Devices.CreateAsync(device);
        }
    }
}