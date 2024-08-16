using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Staff.GetAll
{
    public class GetAllStaffResponse
    {
        public int TotalCount { get; set; }

        public List<StaffVM> Staffs { get; set; }
    }
}
