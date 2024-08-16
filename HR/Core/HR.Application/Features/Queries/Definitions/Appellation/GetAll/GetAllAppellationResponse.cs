using HR.Application.VMs.Definitions;

namespace HR.Application.Features.Queries.Definitions.Appellation.GetAll
{
    public class GetAllAppellationResponse
    {
        public int TotalCount { get; set; }

        public List<AppellationVM> Appellations { get; set; }
    }
}
