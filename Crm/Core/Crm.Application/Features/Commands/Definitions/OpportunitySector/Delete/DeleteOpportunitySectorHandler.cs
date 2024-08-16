using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.OpportunitySector.Delete
{
    public class DeleteOpportunitySectorHandler : IRequestHandler<DeleteOpportunitySectorRequest, DeleteOpportunitySectorResponse>
    {
        readonly IOpportunitySectorWriteRepository  _opportunitySectorWriteRepository;

        public DeleteOpportunitySectorHandler(IOpportunitySectorWriteRepository opportunitySectorWriteRepository)
        {
            _opportunitySectorWriteRepository = opportunitySectorWriteRepository;
        }

        public async  Task<DeleteOpportunitySectorResponse> Handle(DeleteOpportunitySectorRequest request, CancellationToken cancellationToken)
        {
            await _opportunitySectorWriteRepository.SoftDeleteAsync(request.Id);
            await _opportunitySectorWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
