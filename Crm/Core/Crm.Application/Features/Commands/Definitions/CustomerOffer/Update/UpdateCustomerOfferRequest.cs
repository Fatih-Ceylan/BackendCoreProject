using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerOffer.Update
{
    public class UpdateCustomerOfferRequest : IRequest<UpdateCustomerOfferResponse>
    {
        public string Id { get; set; }
    }
}
