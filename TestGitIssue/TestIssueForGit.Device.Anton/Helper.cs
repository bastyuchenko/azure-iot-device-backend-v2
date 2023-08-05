using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace TestIssueForGit.Device.Anton
{
    internal static class Helper
    {
        public static string GlobalDeviceEndpoint = "global.azure-devices-provisioning.net";

        internal static X509Certificate2 LoadProvisioningCertificate(
            string certPassword,
            string certificateName = "deviceName-provisioning-cert-anton.pem",
            string certificatePrivateKeyName = "deviceName-provisioning-key-anton.pem"
           )
        {
            var workingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var certificate = Path.Combine(workingDirectory, certificateName);
            var certificatePrivateKey = Path.Combine(workingDirectory, certificatePrivateKeyName);

            var provisioningCert = File.ReadAllText(certificate);
            var provisioningKey = File.ReadAllText(certificatePrivateKey);

            var sslCert = X509Certificate2.CreateFromEncryptedPem(provisioningCert, provisioningKey, certPassword);
            var _provisioningCertificate = new X509Certificate2(sslCert.Export(X509ContentType.Pkcs12));

            return _provisioningCertificate;
        }
    }
}
