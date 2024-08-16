using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.LeaveType.Delete
{
    public class DeleteLeaveTypeHandler : IRequestHandler<DeleteLeaveTypeRequest, DeleteLeaveTypeResponse>
    {
        readonly ILeaveTypeWriteRepository _leaveTypeWriteRepository;

        public DeleteLeaveTypeHandler(ILeaveTypeWriteRepository LeaveTypeWriteRepository)
        {
            _leaveTypeWriteRepository = LeaveTypeWriteRepository;
        }

        public async Task<DeleteLeaveTypeResponse> Handle(DeleteLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            await _leaveTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _leaveTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
