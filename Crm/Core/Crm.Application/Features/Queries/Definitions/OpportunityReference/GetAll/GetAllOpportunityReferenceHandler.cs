using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityReference.GetAll
{
    public class GetAllOpportunityReferenceHandler : IRequestHandler<GetAllOpportunityReferenceRequest, GetAllOpportunityReferenceResponse>
    {
        readonly IOpportunityReferenceReadRepository _opportunityReferenceReadRepository;

        public GetAllOpportunityReferenceHandler(IOpportunityReferenceReadRepository opportunityReferenceReadRepository)
        {
            _opportunityReferenceReadRepository = opportunityReferenceReadRepository;
        }

        public Task<GetAllOpportunityReferenceResponse> Handle(GetAllOpportunityReferenceRequest request, CancellationToken cancellationToken)
        {
            var query = _opportunityReferenceReadRepository.GetAllDeletedStatusDesc(false)
             .Select(or => new OpportunityReferenceVM
             {
                 Id = or.Id.ToString(),
                 Name = or.Name,
             

             });

            var totalCount = query.Count();
            var Opportunityreferences = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllOpportunityReferenceResponse
            {
                TotalCount = totalCount,
                OpportunityReferences = Opportunityreferences,
            });
        }

    }
}
