using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.SolutionOffer.Delete
{
    public  class DeleteSolutionOfferRequest : IRequest<DeleteSolutionOfferResponse>
    {
        public string Id { get; set; }
    }
}
