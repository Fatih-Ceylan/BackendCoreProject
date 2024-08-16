using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.Leave.Delete
{
    public class DeleteLeaveHandler : IRequestHandler<DeleteLeaveRequest, DeleteLeaveResponse>
    {
        readonly ILeaveWriteRepository _leaveWriteRepository;

        public DeleteLeaveHandler(ILeaveWriteRepository LeaveWriteRepository)
        {
            _leaveWriteRepository = LeaveWriteRepository;
        }

        public async Task<DeleteLeaveResponse> Handle(DeleteLeaveRequest request, CancellationToken cancellationToken)
        {
            await _leaveWriteRepository.SoftDeleteAsync(request.Id);
            await _leaveWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
