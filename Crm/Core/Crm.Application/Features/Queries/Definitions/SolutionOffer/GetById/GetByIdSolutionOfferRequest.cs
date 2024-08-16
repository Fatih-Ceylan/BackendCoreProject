using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.SolutionOffer.GetById
{
    public  class GetByIdSolutionOfferRequest : IRequest<GetByIdSolutionOfferResponse>
    {
        public string  Id { get; set; }
    }
}
