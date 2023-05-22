using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.Devices.Client;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IoT.Device.SASAuth.FileUpload.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IotHubDeviceClient _deviceClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() ?? false)
            {
                var fileUploadSasUriRequest = new FileUploadSasUriRequest(fileDialog.SafeFileName);

                FileUploadSasUriResponse sasUri = await _deviceClient.GetFileUploadSasUriAsync(fileUploadSasUriRequest);
                Uri uploadUri = sasUri.GetBlobUri();
                var blockBlobClient = new BlockBlobClient(uploadUri);

                using System.IO.StreamReader sr = new System.IO.StreamReader(fileDialog.FileName);
                await blockBlobClient.UploadAsync(sr.BaseStream, new BlobUploadOptions());

                var successfulFileUploadCompletionNotification = new FileUploadCompletionNotification(sasUri.CorrelationId, true)
                { 
                    // Optional, user defined status code. Will be present when service client receives this file upload notification
                    StatusCode = 200,

                    // Optional, user-defined status description. Will be present when service client receives this file upload notification
                    StatusDescription = "Success"
                };

                await _deviceClient.CompleteFileUploadAsync(successfulFileUploadCompletionNotification);
            }
        }

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            var connectionString = ConfigurationManager.AppSettings["SasConnectionString"];

            _deviceClient = new IotHubDeviceClient(connectionString);
            _deviceClient.ConnectionStatusChangeCallback = (ConnectionStatusInfo info) =>
            {
                MessageBox.Show($"Device Status {info.Status}; Change reason: {info.ChangeReason}; Recommended action {info.RecommendedAction}.");
            };
            await _deviceClient!.OpenAsync(CancellationToken.None);
            MessageBox.Show($"[DONE] Created DeviceClient instance to communicate through assigned IoT Hub...");
        }
    }
}
