using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;

namespace Platform.Application.Features.Queries.Definitions.GModuleLicenseTypePrice.GetAll
{
    public class GetAllGModuleLicenseTypePriceResponse
    {
        public int TotalCount { get; set; }

        public List<GModuleLicenseTypePriceVM> GModuleLicenseTypePrices { get; set; }
    }
}