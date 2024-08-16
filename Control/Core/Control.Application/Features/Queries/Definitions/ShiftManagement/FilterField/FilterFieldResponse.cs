using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.ShiftManagement.FilterField
{
    public class FilterFieldResponse
    {
        public int TotalCount { get; set; }

        public List<ShiftManagementVM> ShiftManagements { get; set; }
    }
}
