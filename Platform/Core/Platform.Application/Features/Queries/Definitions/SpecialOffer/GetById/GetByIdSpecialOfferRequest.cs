using MediatR;

namespace Platform.Application.Features.Queries.Definitions.SpecialOffer.GetById
{
    public class GetByIdSpecialOfferRequest : IRequest<GetByIdSpecialOfferResponse>
    {
        public string Id { get; set; }
    }
}
