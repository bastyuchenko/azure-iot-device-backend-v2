using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Provisioning.Client;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoT.Device
{
    public partial class Device : Form
    {
        private readonly DeviceParameters _parameters;
        private readonly X509Certificate2 x509Certificate;
        private IotHubDeviceClient deviceClient;
        private CancellationTokenSource streamGenerationToken;
        private IotHubModuleClient moduleClient;
        private AuthenticationProviderX509 security;
        private ProvisioningDetailsFileStorage provisioningDetailCache;
        private ProvisioningResponse provisioningDetails;

        public Device()
        {
            InitializeComponent();

            streamGenerationToken = new CancellationTokenSource();

            _parameters = new DeviceParameters();
            x509Certificate = Helper.LoadProvisioningCertificate(_parameters.CertificateName, _parameters.CertificatePrivateKeyName, _parameters.CertificatePassword);
            Log($"[DONE] PFX Certificate was loaded...");

            // https://learn.microsoft.com/en-us/azure/iot-dps/concepts-deploy-at-scale#reprovisioning-sample
            provisioningDetailCache = new ProvisioningDetailsFileStorage();
            security = new AuthenticationProviderX509(x509Certificate);

            // https://learn.microsoft.com/en-us/azure/iot-dps/concepts-deploy-at-scale#reprovisioning-sample
            provisioningDetails = provisioningDetailCache.GetProvisioningDetailResponseFromCache(security.GetRegistrationId());
            tbAssignedHub.Text = provisioningDetails?.IotHubHostName;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            Log($"Initializing for registration Id {security.GetRegistrationId()}.");
            Log("Initializing the device provisioning client...");
            var provClient = new ProvisioningDeviceClient(
                _parameters.GlobalDeviceEndpoint,
                _parameters.IdScope,
                security,
                options: new ProvisioningClientOptions(new ProvisioningClientMqttSettings()));

            Log($"Initialized for registration Id {security.GetRegistrationId()}.");

            Log("Registering with the device provisioning service... ");
            var result = await provClient.RegisterAsync();
            provisioningDetails = new ProvisioningResponse() { IotHubHostName = result.AssignedHub, DeviceId = result.DeviceId };
            provisioningDetailCache.SetProvisioningDetailResponse(security.GetRegistrationId(), provisioningDetails);
            tbAssignedHub.Text = provisioningDetails?.IotHubHostName;

            Log($"Registration status: {result.Status}.");
            if (result.Status != ProvisioningRegistrationStatus.Assigned)
                throw new Exception("Registration status did not assign a hub. Registration status '{result.Status}' received.");

            Log($"[DONE] Device {security.GetRegistrationId()} registered to {result.AssignedHub}.");
        }

        private async void btnCreateClient_Click(object sender, EventArgs e)
        {
            if (deviceClient is not null)
            {
                await deviceClient.DisposeAsync();
            }

            if (string.IsNullOrWhiteSpace(tbAssignedHub.Text)) { MessageBox.Show("Please register device before start."); return; }
            Log("Creating X509 authentication for IoT Hub...");
            IAuthenticationMethod auth = new ClientAuthenticationWithX509Certificate(x509Certificate, security.GetRegistrationId());

            deviceClient = new IotHubDeviceClient(provisioningDetails.IotHubHostName, auth, new IotHubClientOptions(new IotHubClientMqttSettings()));
            deviceClient.ConnectionStatusChangeCallback = (ConnectionStatusInfo info) =>
            {
                Log($"Device Status {info.Status}; Change reason: {info.ChangeReason}; Recommended action {info.RecommendedAction}.");
            };
            await deviceClient!.OpenAsync(CancellationToken.None);
            Log($"[DONE] Created DeviceClient instance to communicate through assigned IoT Hub...");
        }

        private async void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (deviceClient == null) { Log("Assigned IoT Hub name was not stored. Please register one more time to get IoT Hub name."); return; }

            Log("Sending a telemetry message...");
            var message = new TelemetryMessage(Encoding.UTF8.GetBytes(tbMsg.Text));
            await deviceClient.SendTelemetryAsync(message);
            Log("Finished.");
        }

        private async void btnStartTelemetryMessageReceiving_Click(object sender, EventArgs e)
        {
            if (deviceClient == null) { Log("Assigned IoT Hub name was not stored. Please register one more time to get IoT Hub name."); return; }

            Log("Receiving cloud to device messages from service");

            await deviceClient.SetIncomingMessageCallbackAsync(
                async (IncomingMessage message) =>
                {
                    message.TryGetPayload<string>(out var payload);
                    tbReceivedMsg.AppendText(JsonConvert.SerializeObject(
                        new
                        {
                            Body = payload,
                            message.Properties,
                            message.MessageId,
                            message.To,
                            message.CorrelationId
                        }, Formatting.Indented));

                    return MessageAcknowledgement.Complete;
                }).ConfigureAwait(false);
        }

        private Task<MessageAcknowledgement> sss(IncomingMessage arg)
        {
            throw new NotImplementedException();
        }

        private async void btnWReported_Click(object sender, EventArgs e)
        {
            ReportedProperties reportedProperties, connectivity;
            reportedProperties = new ReportedProperties();

            connectivity = new ReportedProperties();
            connectivity["type"] = "cellular";
            reportedProperties["connectivity"] = connectivity;

            reportedProperties["body"] = tbDTReport.Text;

            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties);
        }

        private async void btnRDesired_Click(object sender, EventArgs e)
        {
            await deviceClient.SetDesiredPropertyUpdateCallbackAsync(callback: async (DesiredProperties desiredProperties) =>
            {
                tbDTRead.Text = JsonConvert.SerializeObject(desiredProperties);
            },
            cancellationToken: CancellationToken.None);
        }

        private Task ssdsdsd(DesiredProperties arg)
        {
            throw new NotImplementedException();
        }

        private async void btnGenStream_Click(object sender, EventArgs e)
        {
            streamGenerationToken = new CancellationTokenSource();

            // Initial telemetry values.
            double minTemperature = 20;
            double minHumidity = 60;
            var rand = new Random();

            try
            {
                while (!streamGenerationToken.Token.IsCancellationRequested)
                {
                    double currentTemperature = minTemperature + rand.NextDouble() * 15;
                    double currentHumidity = minHumidity + rand.NextDouble() * 20;

                    // Create JSON message.
                    string messageBody = JsonConvert.SerializeObject(
                        new
                        {
                            temperature = currentTemperature,
                            humidity = currentHumidity,
                        }, Formatting.Indented);

                    var message = new TelemetryMessage(messageBody);

                    // Add a custom application property to the message.
                    // An IoT hub can filter on these properties without access to the message body.
                    message.Properties.Add("temperatureAlert", (currentTemperature > 30) ? "true" : "false");

                    // Send the telemetry message.
                    await deviceClient.SendTelemetryAsync(message, streamGenerationToken.Token);
                    tbMsgsExample.AppendText(JsonConvert.SerializeObject(new
                    {
                        Body = messageBody,
                        message.ContentType,
                        message.ContentEncoding,
                        message.Properties
                    }, Formatting.Indented) + "\r\n");

                    await Task.Delay(TimeSpan.FromMilliseconds(500), streamGenerationToken.Token);
                }
            }
            catch (TaskCanceledException) { } // User canceled
        }

        private void btnGenerateStreamStop_Click(object sender, EventArgs e)
        {
            streamGenerationToken.Cancel();
        }

        private void Log(string text)
        {
            lbStatus.AppendText("\r\n" + text);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
        }

        private void Device_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private async void btnReadDT_Click(object sender, EventArgs e)
        {
            var twin = await deviceClient.GetTwinPropertiesAsync();
            throw new NotImplementedException();
            Log("Device Twin content was read");
        }

        private async void btnModuleTwinDesiredPropsSubsr_Click(object sender, EventArgs e)
        {
            await moduleClient.SetDesiredPropertyUpdateCallbackAsync((DesiredProperties desiredProperties) =>
            {
                tbModuletwinDesProps.Text = JsonConvert.SerializeObject(desiredProperties);
                return Task.CompletedTask;
            }, CancellationToken.None);
        }

        private async void btnModuleTwinRepProps_Click(object sender, EventArgs e)
        {
            ReportedProperties reportedProperties = new ReportedProperties
            {
                ["MyDateTimeLastDesiredPropertyChangeReceived"] = tbModuleTwinRepProps.Text
            };
            await moduleClient.UpdateReportedPropertiesAsync(reportedProperties);
        }

        private async void btnSubscribeDirectMethod_Click(object sender, EventArgs e)
        {
            await deviceClient.SetDirectMethodCallbackAsync(
            async (DirectMethodRequest methodRequest) =>
                {
                    methodRequest.TryGetPayload(out string data);

                    // Check the payload is a single integer value.
                    if (int.TryParse(data, out int telemetryIntervalInSeconds))
                    {
                        var s_telemetryInterval = TimeSpan.FromSeconds(telemetryIntervalInSeconds);

                        MessageBox.Show(s_telemetryInterval.TotalSeconds.ToString());

                        // Acknowlege the direct method call with a 200 success message.
                        string result = $"{{\"result\":\"Executed direct method: {methodRequest.MethodName}\"}}";
                        return new DirectMethodResponse(200)
                        {
                            Payload = Encoding.UTF8.GetBytes(result)
                        };
                    }
                    else
                    {
                        // Acknowlege the direct method call with a 400 error message.
                        string result = "{\"result\":\"Invalid parameter\"}";
                        return new DirectMethodResponse(400)
                        {
                            Payload = Encoding.UTF8.GetBytes(result)
                        };
                    }
                },
                CancellationToken.None);
        }

        private async void btnModuleClient_Click(object sender, EventArgs e)
        {
            var options = new IotHubClientOptions(new IotHubClientMqttSettings());

            moduleClient = new IotHubModuleClient(_parameters.ModuleConnectionString, options);
            moduleClient.ConnectionStatusChangeCallback = (ConnectionStatusInfo info) =>
            {
                Log($"Module Status {info.Status}; Change reason: {info.ChangeReason}; Recommended action {info.RecommendedAction}.");
            };

            Log($"[DONE] Created ModuleClient instance to communicate through assigned IoT Hub...");

        }

        private async void btnStopTelemetryMessageReceiving_Click(object sender, EventArgs e)
        {
            await deviceClient.SetIncomingMessageCallbackAsync(null).ConfigureAwait(false);
        }
    }
}