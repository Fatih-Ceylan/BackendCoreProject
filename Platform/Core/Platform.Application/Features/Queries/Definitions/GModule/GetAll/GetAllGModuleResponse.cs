using Platform.Application.VMs.Definitions.GModule;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetAll
{
    public class GetAllGModuleResponse
    {
        public int TotalCount { get; set; }

        public List<GModuleVM> GModules { get; set; }

    }
}
