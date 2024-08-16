using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CompanyOffer.GetAll
{
    public  class GetAllCompanyOfferResponse
    {
        public int TotalCount { get; set; }
        public List<CompanyOfferVM>  CompanyOffers { get; set; }
    }
}
