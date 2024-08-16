using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.StaffField.GetAllFieldByStaffId
{
    public class GetAllFieldByStaffIdStaffFieldResponse
    {
        public int TotalCount { get; set; }
        public List<StaffFieldVM> StaffFields { get; set; }
    }
}
