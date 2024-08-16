using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.Customer.GetAll
{
    public class GetAllCustomerResponse
    {
        public int TotalCount { get; set; }/////

        public List<CustomerVM> Customers { get; set; }
    }
}