using GCharge.Application.VMs.Definitions;

namespace GCharge.Application.Features.Queries.Definitions.UserChargeTag.GetAll
{
    public class GetAllUserChargeTagResponse
    {
        public int TotalCount { get; set; }

        public List<UserChargeTagVM> UserChargeTags { get; set; }
    }
}