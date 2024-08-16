namespace Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Update
{
    public class UpdateGModuleLicenseTypePriceResponse
    {
        public string Id { get; set; }

        public string GModuleId { get; set; }

        public string LicenseTypeId { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }

        public string Message { get; set; }
    }
}