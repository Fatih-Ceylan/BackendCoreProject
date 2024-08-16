using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetAll
{
    public class GetAllStaffContactResponse
    {
        public int TotalCount { get; set; }

        public List<StaffContactVM> StaffContacts { get; set; }
    }
}
