using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityType.GetAll
{
    public  class GetAllCustomerActivityTypeResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerActivityTypeVM> customerActivityTypes { get; set; }
    }
}
