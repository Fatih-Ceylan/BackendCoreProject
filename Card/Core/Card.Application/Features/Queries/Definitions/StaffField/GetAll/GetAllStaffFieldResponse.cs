using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.StaffField.GetAll
{
    public class GetAllStaffFieldResponse
    {
        public int TotalCount { get; set; }

        public List<StaffFieldVM> StaffFields { get; set; }
    }
}
