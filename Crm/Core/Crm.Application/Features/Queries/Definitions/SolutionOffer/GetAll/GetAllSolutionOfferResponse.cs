using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.SolutionOffer.GetAll
{
    public  class GetAllSolutionOfferResponse
    {
        public int TotalCount { get; set; }

        public List<SolutionOfferVM>  SolutionOffers { get; set; }
    }
}
