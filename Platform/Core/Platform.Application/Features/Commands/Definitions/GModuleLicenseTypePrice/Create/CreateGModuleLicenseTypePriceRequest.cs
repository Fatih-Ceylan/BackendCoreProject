using MediatR;

namespace Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Create
{
    public class CreateGModuleLicenseTypePriceRequest: IRequest<CreateGModuleLicenseTypePriceResponse>
    {
        public string GModuleId { get; set; }

        public string LicenseTypeId { get; set; }

        public decimal Amount { get; set; }

        public decimal AUserPriceForAMonth { get; set; }

        public decimal ACompanyPriceForAMonth { get; set; }

        public decimal TaxRate { get; set; }
    }
}