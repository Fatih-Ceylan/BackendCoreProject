using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerKind.GetAll
{
    public class GetAllCustomerKindResponse
    {
        public int TotalCount { get; set; }
        public List<CustomerKindVM> CustomerKinds { get; set; }
    }
}
