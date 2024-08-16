using MediatR;

namespace Platform.Application.Features.Commands.Definitions.SpecialOffer.Delete
{
    public class DeleteSpecialOfferRequest : IRequest<DeleteSpecialOfferResponse>
    {
        public string Id { get; set; }
    }
}
