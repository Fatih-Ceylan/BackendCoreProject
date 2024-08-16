using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerOffer.Delete
{
    public class DeleteCustomerOfferRequest : IRequest<DeleteCustomerOfferResponse>
    {
        public string Id { get; set; }
    }
}
