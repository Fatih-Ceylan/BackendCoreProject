using Platform.Application.VMs.Definitions.GModule;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetById
{
    public class GetByIdGModuleResponse
    {
        public GModuleVM GModule { get; set; }

        public List<GModuleLicenseTypePriceUpdateVM> GModuleLicenseTypePrices { get; set; }
    }
}
