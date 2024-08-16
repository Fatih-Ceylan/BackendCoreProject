using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Location.NumberOfEmployeesOfLocations
{
    public class NumberOfEmployeesOfLocationsResponse
    {
        public int TotalCount { get; set; }

        public List<LocationGroupEmployeeVM> Locations { get; set; }
    }
}
