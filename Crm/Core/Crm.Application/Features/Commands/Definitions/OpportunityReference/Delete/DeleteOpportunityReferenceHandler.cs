using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityReference.Delete
{
    public class DeleteOpportunityReferenceHandler : IRequestHandler<DeleteOpportunityReferenceRequest, DeleteOpportunityReferenceResponse>
    {
        readonly IOpportunityReferenceWriteRepository _opportunityReferenceWriteRepository;
        public DeleteOpportunityReferenceHandler(IOpportunityReferenceWriteRepository opportunityReferenceWriteRepository)
        {
            _opportunityReferenceWriteRepository = opportunityReferenceWriteRepository;
        }

        public async  Task<DeleteOpportunityReferenceResponse> Handle(DeleteOpportunityReferenceRequest request, CancellationToken cancellationToken)
        {
            await _opportunityReferenceWriteRepository.SoftDeleteAsync(request.Id);
            await _opportunityReferenceWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
