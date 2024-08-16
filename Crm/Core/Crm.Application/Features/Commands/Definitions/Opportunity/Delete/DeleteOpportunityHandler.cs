using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.Opportunity.Delete
{
    public class DeleteOpportunityHandler : IRequestHandler<DeleteOpportunityRequest, DeleteOpportunityResponse>
    {
        readonly IOpportunityWriteRepository _opportunityWriteRepository;

        public DeleteOpportunityHandler(IOpportunityWriteRepository  opportunityWriteRepository)
        {
            _opportunityWriteRepository = opportunityWriteRepository;
        }

        public async Task<DeleteOpportunityResponse> Handle(DeleteOpportunityRequest request, CancellationToken cancellationToken)
        {
            await _opportunityWriteRepository.SoftDeleteAsync(request.Id);
            await _opportunityWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
