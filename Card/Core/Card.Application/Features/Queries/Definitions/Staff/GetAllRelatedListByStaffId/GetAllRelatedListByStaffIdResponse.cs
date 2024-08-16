using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Staff.GetAllRelatedListByStaffId
{
    public class GetAllRelatedListByStaffIdResponse
    {
        public List<GetRelatedListByStaffIdVM> RelatedList { get; set; }

    }
}
