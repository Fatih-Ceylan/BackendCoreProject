using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Location.FilterField
{
    public class FilterFieldResponse
    {
        public int TotalCount { get; set; }

        public List<LocationVM> Locations { get; set; }
    }
}
