using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityKind.GetAll
{
    public  class GetAllCustomerActivityKindResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerActivityKindVM> customerActivityKinds { get; set; }
    }
}
