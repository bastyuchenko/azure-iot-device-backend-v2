﻿using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace IoT.Device.Wpf
{
    internal static class Helper
    {
        public static X509Certificate2 LoadProvisioningCertificate(string certificateName, string certificatePrivateKeyName, string certPassword)
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