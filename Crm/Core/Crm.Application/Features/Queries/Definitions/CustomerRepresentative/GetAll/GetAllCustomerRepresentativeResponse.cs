using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerRepresentative.GetAll
{
    public  class GetAllCustomerRepresentativeResponse
    {
        public int TotalCount { get; set; }
        public List<CustomerRepresentativeVM>  CustomerRepresentatives { get; set; }
    }
}
