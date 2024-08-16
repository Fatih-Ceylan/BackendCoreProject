using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerOffer.GetAll
{
    public  class GetAllCustomerOfferResponse
    {
        public int TotalCount { get; set; }
        public List<CustomerOfferVM> customerOfferVM { get; set; }
    }
}
