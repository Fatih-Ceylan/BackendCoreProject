using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.SolutionOffer.Create
{
    public class CreateSolutionOfferRequest : IRequest<CreateSolutionOfferResponse>
    {
        public string Name { get; set; }
    }
}
