using GenerateCertificates.Certificates;
using System.Security.Cryptography.X509Certificates;

namespace GenerateCertificates
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var provisioningCertificate = Certificate.GenerateRsaCertificate("iothubx509device1-test");

            await File.WriteAllTextAsync(
                    "deviceName-provisioning-cert-test.pem",
                provisioningCertificate.GetCertificate());

            await File.WriteAllTextAsync(
                    "deviceName-provisioning-key-test.pem",
                provisioningCertificate.GetPrivateKey());

            var provisioningCert = await File.ReadAllTextAsync("deviceName-provisioning-cert-test.pem");
            var provisioningKey = await File.ReadAllTextAsync("deviceName-provisioning-key-test.pem");

            var sslCert = X509Certificate2.CreateFromEncryptedPem(provisioningCert, provisioningKey, "Qwer!234");
            // https://github.com/dotnet/runtime/issues/23749#issuecomment-747407051
            var _provisioningCertificate = new X509Certificate2(sslCert.Export(X509ContentType.Pkcs12));
        }
    }
}

// https://learn.microsoft.com/en-us/azure/iot-dps/quick-enroll-device-x509?pivots=programming-language-csharp