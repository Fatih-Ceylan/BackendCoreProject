using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityStage.GetById
{
    public  class GetByIdOpportunityStageHandler : IRequestHandler<GetByIdOpportunityStageRequest, GetByIdOpportunityStageResponse>
    {
        readonly IOpportunityStageReadRepository _opportunityStageReadRepository;

        public GetByIdOpportunityStageHandler(IOpportunityStageReadRepository  opportunityStageReadRepository)
        {
            _opportunityStageReadRepository = opportunityStageReadRepository;
        }

        public async Task<GetByIdOpportunityStageResponse> Handle(GetByIdOpportunityStageRequest request, CancellationToken cancellationToken)
        {
            var opportunitystages = _opportunityStageReadRepository
                      .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                      .Select(ct => new OpportunityStageVM
                      {
                          Id = ct.Id.ToString(),
                          Name = ct.Name

                      }).FirstOrDefault();

            return new()
            {
                OpportunityStage = opportunitystages
            };
        }
    }
}
