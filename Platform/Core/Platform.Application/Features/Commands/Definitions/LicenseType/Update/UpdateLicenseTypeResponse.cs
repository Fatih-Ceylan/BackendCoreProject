namespace Platform.Application.Features.Commands.Definitions.LicenseType.Update
{
    public class UpdateLicenseTypeResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int UsageMounth { get; set; }

        public int UserNumber { get; set; }

        public int CompanyNumber { get; set; }

        public string Message { get; set; }
    }
}