using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityStage.GetAll
{
    public  class GetAllOpportunityStageHandler : IRequestHandler<GetAllOpportunityStageRequest, GetAllOpportunityStageResponse>
    {
        readonly IOpportunityStageReadRepository  _opportunityStageReadRepository;

        public GetAllOpportunityStageHandler(IOpportunityStageReadRepository  opportunityStageReadRepository)
        {
            _opportunityStageReadRepository = opportunityStageReadRepository;
        }

        public Task<GetAllOpportunityStageResponse> Handle(GetAllOpportunityStageRequest request, CancellationToken cancellationToken)
        {
            var query = _opportunityStageReadRepository.GetAllDeletedStatusDesc(false)
             .Select(or => new OpportunityStageVM
             {
                 Id = or.Id.ToString(),
                 Name = or.Name,


             });

            var totalCount = query.Count();
            var Opportunitystages = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllOpportunityStageResponse
            {
                TotalCount = totalCount,
                OpportunityStages = Opportunitystages,
            });
        }

    }
}
