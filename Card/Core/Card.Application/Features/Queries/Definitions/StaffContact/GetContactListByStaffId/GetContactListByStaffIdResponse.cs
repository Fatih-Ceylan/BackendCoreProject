using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetContactListByStaffId
{
    public class GetContactListByStaffIdResponse
    {
        public int TotalCount { get; set; }
        public List<StaffContactVM> Contacts { get; set; }
    }
}
