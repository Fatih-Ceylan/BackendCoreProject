using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivity.GetAll
{
    public class GetAllCustomerActivityResponse
    {
        public int TotalCount { get; set; }
        public List<CustomerActivityVM> CustomerActivities { get; set; }
    }
}
