using GCharge.Application.VMs.Definitions;

namespace GCharge.Application.Features.Queries.Definitions.ChargePoint.GetAll
{
    public class GetAllChargePointResponse
    {
        public int TotalCount { get; set; }

        public List<ChargePointVM> ChargePoints { get; set; }
    }
}