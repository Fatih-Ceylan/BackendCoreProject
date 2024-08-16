using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.Delete
{
    public class DeleteEntryExitManagementHandler : IRequestHandler<DeleteEntryExitManagementRequest, DeleteEntryExitManagementResponse>
    {
        readonly IEntryExitManagementWriteRepository _entryExitManagementWriteRepository;

        public DeleteEntryExitManagementHandler(IEntryExitManagementWriteRepository entryExitManagementWriteRepository)
        {
            _entryExitManagementWriteRepository = entryExitManagementWriteRepository;
        }

        public async Task<DeleteEntryExitManagementResponse> Handle(DeleteEntryExitManagementRequest request, CancellationToken cancellationToken)
        {
            await _entryExitManagementWriteRepository.SoftDeleteAsync(request.Id);
            await _entryExitManagementWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
