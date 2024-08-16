using GCharge.Application.VMs.Definitions;

namespace GCharge.Application.Features.Queries.Definitions.ChargeTag.GetAll
{
    public class GetAllChargeTagResponse
    {
        public int TotalCount { get; set; }

        public List<ChargeTagVM> ChargeTags { get; set; }
    }
}
