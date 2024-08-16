using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.SolutionOffer.GetById
{
    public class GetByIdSolutionOfferHandler : IRequestHandler<GetByIdSolutionOfferRequest, GetByIdSolutionOfferResponse>
    {
        readonly ISolutionOfferReadRepository  _solutionOfferReadRepository;

        public GetByIdSolutionOfferHandler(ISolutionOfferReadRepository solutionOfferReadRepository)
        {
            _solutionOfferReadRepository= solutionOfferReadRepository;

        }
        public async Task<GetByIdSolutionOfferResponse> Handle(GetByIdSolutionOfferRequest request, CancellationToken cancellationToken)
        {
            var SolutionOffers = _solutionOfferReadRepository
                        .GetWhere(so => so.Id == Guid.Parse(request.Id), false)
                        .Select(so => new SolutionOfferVM
                        {
                            Id = so.Id.ToString()
                            
                        }).FirstOrDefault();

            return new()
            {
                SolutionOffer = SolutionOffers
            };
        }
    }
}
