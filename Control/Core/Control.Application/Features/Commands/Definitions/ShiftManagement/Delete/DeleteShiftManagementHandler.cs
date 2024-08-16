using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.ShiftManagement.Delete
{
    public class DeleteShiftManagementHandler : IRequestHandler<DeleteShiftManagementRequest, DeleteShiftManagementResponse>
    {
        readonly IShiftManagementWriteRepository _shiftManagementWriteRepository;

        public DeleteShiftManagementHandler(IShiftManagementWriteRepository shiftManagementWriteRepository)
        {
            _shiftManagementWriteRepository = shiftManagementWriteRepository;
        }

        public async Task<DeleteShiftManagementResponse> Handle(DeleteShiftManagementRequest request, CancellationToken cancellationToken)
        {
            await _shiftManagementWriteRepository.SoftDeleteAsync(request.Id);
            await _shiftManagementWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
