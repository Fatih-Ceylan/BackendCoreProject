using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerOffer.Create
{
    public class CreateCustomerOfferRequest : IRequest<CreateCustomerOfferResponse>
    {
        public string OfferNo { get; set; }
        public string OfferSubject { get; set; }
        public DateTime OfferDate { get; set; }
        public int TotalAmount { get; set; }
        public string OfferStatus { get; set; }
        public string CreatedUser { get; set; }
    }
}
