using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.ShiftManagement.GetAll
{
    public class GetAllShiftManagementResponse
    {
        public int TotalCount { get; set; }

        public List<ShiftManagementVM> ShiftManagements { get; set; }
    }
}
