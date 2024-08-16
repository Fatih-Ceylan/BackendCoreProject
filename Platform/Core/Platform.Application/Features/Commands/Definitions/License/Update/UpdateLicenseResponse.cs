namespace Platform.Application.Features.Commands.Definitions.License.Update
{
    public class UpdateLicenseResponse
    {
        public string Id { get; set; }

        public string CompanyId { get; set; }

        public string GModuleId { get; set; }

        public string LicenseTypeId { get; set; }

        public string LicenseKey { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int TotalCompanyNumber { get; set; }

        public int TotalUserNumber { get; set; }

        public string Message { get; set; }
    }
}