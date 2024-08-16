using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityStatus.GetAll
{
    public  class GetAllCustomerActivityStatusResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerActivityStatusVM> customerActivityStatuses { get; set; }
    }
}
