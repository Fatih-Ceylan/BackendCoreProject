using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSource.GetAll
{
    public class GetAllCustomerSourceResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerSourceVM> CustomerSources { get; set; }
    }
}
