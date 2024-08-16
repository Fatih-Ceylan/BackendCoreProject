using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunityReference.GetById
{
    public class GetByIdOpportunityReferenceHandler : IRequestHandler<GetByIdOpportunityReferenceRequest, GetByIdOpportunityReferenceResponse>
    {
        readonly IOpportunityReferenceReadRepository  _opportunityReferenceReadRepository;

        public GetByIdOpportunityReferenceHandler(IOpportunityReferenceReadRepository opportunityReferenceReadRepository)
        {
            _opportunityReferenceReadRepository = opportunityReferenceReadRepository;
        }

        public async  Task<GetByIdOpportunityReferenceResponse> Handle(GetByIdOpportunityReferenceRequest request, CancellationToken cancellationToken)
        {
            var opportunityreferences = _opportunityReferenceReadRepository
                        .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                        .Select(ct => new OpportunityReferenceVM
                        {
                            Id = ct.Id.ToString(),
                            Name = ct.Name  

                        }).FirstOrDefault();

            return new()
            {
                OpportunityReference = opportunityreferences
            };
        }
    }
}
