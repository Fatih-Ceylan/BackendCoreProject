using GCharge.Application.VMs.Definitions;

namespace GCharge.Application.Features.Queries.Definitions.ElectricitySalesPrice.GetAll
{
    public class GetAllElectricitySalesPriceResponse
    {
        public int TotalCount { get; set; }

        public List<ElectricitySalesPriceVM>  ElectricitySalesPrices { get; set; }
    }
}
