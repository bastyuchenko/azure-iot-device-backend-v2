using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace TestCreateEnrollment.Anton
{
    internal static class Helper
    {
        internal const string IdScope = "0ne0050D9A6"; // anton

        internal static X509Certificate2 LoadProvisioningCertificate(
            string certificateName = "deviceName-provisioning-cert-anton.pem",
            string certificatePrivateKeyName = "deviceName-provisioning-key-anton.pem",
            string certPassword = "Qwer!234",
            bool includeKey = true)
        {
            var workingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var certificate = Path.Combine(workingDirectory, certificateName);
            var provisioningCert = File.ReadAllText(certificate);

            if (includeKey)
            {
                var certificatePrivateKey = Path.Combine(workingDirectory, certificatePrivateKeyName);

                var provisioningKey = File.ReadAllText(certificatePrivateKey);

                var sslCert = X509Certificate2.CreateFromEncryptedPem(provisioningCert, provisioningKey, certPassword);
                return new X509Certificate2(sslCert.Export(X509ContentType.Pkcs12));
            }
            else
            {
                var sslCert = X509Certificate2.CreateFromPem(provisioningCert);
                return new X509Certificate2(sslCert.Export(X509ContentType.Pkcs12));
            }
        }

        internal static X509Certificate2 LoadProvisioningCertificateWithoutKey()
        {
            return LoadProvisioningCertificate("deviceName-provisioning-cert-anton.pem", string.Empty, string.Empty, false);
        }
    }
}
