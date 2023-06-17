using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace TestIssueForGit.Backend.Anton
{
    internal static class Helper
    {
        internal const string IdScope = "0ne0050D9A6"; // anton

        internal const string DeviceId = "iothubx509device1-anton";

        internal static X509Certificate2 LoadProvisioningCertificate(
            string certificateName = "deviceName-provisioning-cert-anton.pem")
        {
            var workingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var certificate = Path.Combine(workingDirectory, certificateName);
            var provisioningCert = File.ReadAllText(certificate);

            var sslCert = X509Certificate2.CreateFromPem(provisioningCert);
            return new X509Certificate2(sslCert.Export(X509ContentType.Pkcs12));
        }
    }
}
