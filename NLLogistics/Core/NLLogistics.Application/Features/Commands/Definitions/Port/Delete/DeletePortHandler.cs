using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Port.Delete
{
    public class DeletePortHandler : IRequestHandler<DeletePortRequest, DeletePortResponse>
    {
        readonly IPortWriteRepository _portWriteRepository;

        public DeletePortHandler(IPortWriteRepository portWriteRepository)
        {
            _portWriteRepository = portWriteRepository;
        }

        public async Task<DeletePortResponse> Handle(DeletePortRequest request, CancellationToken cancellationToken)
        {
            await _portWriteRepository.SoftDeleteAsync(request.Id);
            await _portWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}