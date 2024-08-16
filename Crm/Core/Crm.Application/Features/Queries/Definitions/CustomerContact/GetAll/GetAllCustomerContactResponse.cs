using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerContact.GetAll
{
    public class GetAllCustomerContactResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerContactVM> CustomerContacts { get; set; }
    }
}
