using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.SolutionOffer.Update
{
    public  class UpdateSolutionOfferRequest : IRequest<UpdateSolutionOfferResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
