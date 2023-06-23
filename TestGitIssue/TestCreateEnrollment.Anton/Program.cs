using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Provisioning.Service;

namespace TestCreateEnrollment.Anton
{
    internal class Program
    {
        private static string EnrollmentGroupId = "enrollmentgrouptest";

        static async Task Main(string[] args)
        {
            await CreateIndividualEnrollment();
        }

        private static async Task CreateIndividualEnrollment()
        {
            using (ProvisioningServiceClient provisioningServiceClient = new ProvisioningServiceClient(ConfigurationManager.AppSettings["ProvisioningConnectionString"]))
            {
                #region Create a new individual enrollment config
                Console.WriteLine("\nCreating a new enrollmentGroup...");

                var certificate = Helper.LoadProvisioningCertificateWithoutKey();
                Attestation attestation = X509Attestation.CreateFromClientCertificates(certificate);

                var registrationId = certificate.GetNameInfo(X509NameType.SimpleName, false);

                IndividualEnrollment individualEnrollment =
                        new IndividualEnrollment(registrationId, attestation)
                        {
                            ProvisioningStatus = ProvisioningStatus.Enabled
                        };
                #endregion

                #region Create the enrollmentGroup
                Console.WriteLine("\nAdding new enrollmentGroup...");
                IndividualEnrollment enrollmentGroupResult =
                    await provisioningServiceClient.IndividualEnrollments.CreateOrUpdateAsync(individualEnrollment);
                #endregion
            }
        }


        private static async Task DeleteIndividualEnrollment()
        {
            using (ProvisioningServiceClient provisioningServiceClient = new ProvisioningServiceClient(ConfigurationManager.AppSettings["ProvisioningConnectionString"]))
            {
                provisioningServiceClient.IndividualEnrollments.DeleteAsync("iothubx509device1");

                #region Create a new individual enrollment config
                Console.WriteLine("\nCreating a new enrollmentGroup...");
                var certificate = Helper.LoadProvisioningCertificate(ConfigurationManager.AppSettings["CertPassword"]);
                Attestation attestation = X509Attestation.CreateFromRootCertificates(certificate);

                IndividualEnrollment individualEnrollment =
                        new IndividualEnrollment("iothubx509device1", attestation)
                        {
                            ProvisioningStatus = ProvisioningStatus.Enabled
                        };
                #endregion

                #region Create the enrollmentGroup
                Console.WriteLine("\nAdding new enrollmentGroup...");
                IndividualEnrollment enrollmentGroupResult =
                    await provisioningServiceClient.IndividualEnrollments.CreateOrUpdateAsync(individualEnrollment);
                #endregion
            }
        }
    }
}