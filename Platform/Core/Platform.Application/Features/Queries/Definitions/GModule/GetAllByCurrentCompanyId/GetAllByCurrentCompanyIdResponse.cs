using Platform.Application.VMs.Definitions.GModule;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetAllByCurrentCompanyId
{
    public class GetAllByCurrentCompanyIdResponse
    {
        public int TotalCount { get; set; }

        public List<GModuleLicenseStatusVM> GModules { get; set; }
    }
}
