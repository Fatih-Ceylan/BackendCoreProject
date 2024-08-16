using Platform.Application.VMs.Definitions.SpecialOffer;

namespace Platform.Application.Features.Queries.Definitions.SpecialOffer.GetAll
{
    public class GetAllSpecialOfferResponse
    {
        public int TotalCount { get; set; }

        public List<SpecialOfferVM> SpecialOffers { get; set; }
    }
}
