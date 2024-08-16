using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Location.GetAll
{
    public class GetAllLocationResponse
    {
        public int TotalCount { get; set; }

        public List<LocationVM> Locations { get; set; }
    }
}
