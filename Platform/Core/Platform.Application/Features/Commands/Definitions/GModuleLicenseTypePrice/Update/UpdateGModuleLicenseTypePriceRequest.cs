using MediatR;

namespace Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Update
{
    public class UpdateGModuleLicenseTypePriceRequest: IRequest<UpdateGModuleLicenseTypePriceResponse>
    {
        public string Id { get; set; }

        public string GModuleId { get; set; }

        public string LicenseTypeId { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }
    }
}