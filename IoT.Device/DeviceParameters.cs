﻿using Microsoft.Azure.Devices.Client;
using System.Configuration;

namespace IoT.Device
{
    internal class DeviceParameters
    {
        /// <summary>
        ///     The CER certificate to load for device provisioning authentication.
        /// </summary>
        public string CertificateCerName = "deviceName-provisioning-cert.pem";

        /// <summary>
        ///     "The password of the PFX certificate file. If not specified, the program will prompt at run time."
        /// </summary>
        public string CertificatePassword = ConfigurationSettings.AppSettings["CertificatePassword"];

        /// <summary>
        ///     "The certificate with public key to load for device provisioning authentication."
        /// </summary>
        public string CertificateName = "deviceName-provisioning-cert.pem";

        /// <summary>
        ///     "The private key to load for device provisioning authentication."
        /// </summary>
        public string CertificatePrivateKeyName = "deviceName-provisioning-key.pem";

        /// <summary>
        ///     The global endpoint for devices to connect to.
        /// </summary>
        public string GlobalDeviceEndpoint = "global.azure-devices-provisioning.net";

        /// <summary>
        ///     The Id Scope of the DPS instance
        /// </summary>
        public string IdScope = ConfigurationSettings.AppSettings["IdScope"];

        public string ModuleConnectionString = ConfigurationSettings.AppSettings["ModuleConnectionString"];
    }
}