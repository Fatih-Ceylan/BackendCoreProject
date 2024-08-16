using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.SolutionOffer.GetAll
{
    public class GetAllSolutionOfferHandler : IRequestHandler<GetAllSolutionOfferRequest, GetAllSolutionOfferResponse>
    {
        readonly ISolutionOfferReadRepository  _solutionOfferReadRepository;

        public GetAllSolutionOfferHandler(ISolutionOfferReadRepository solutionOfferReadRepository)
        {
            _solutionOfferReadRepository = solutionOfferReadRepository;
        }

        public Task<GetAllSolutionOfferResponse> Handle(GetAllSolutionOfferRequest request, CancellationToken cancellationToken)
        {
            var query = _solutionOfferReadRepository
                                  .GetAllDeletedStatusDesc(false)
                                  .Select(so => new SolutionOfferVM
                                  {
                                      Id = so.Id.ToString(),
                                      Name = so.Name,
                                     
                                  });

            var totalCount = query.Count();
            var SolutionOfferss = query.Skip(request.Page * request.Size)
                             .Take(request.Size).ToList();

            return Task.FromResult(new GetAllSolutionOfferResponse
            {
                TotalCount = totalCount,
                SolutionOffers = SolutionOfferss,
            });
        }
    }
}
