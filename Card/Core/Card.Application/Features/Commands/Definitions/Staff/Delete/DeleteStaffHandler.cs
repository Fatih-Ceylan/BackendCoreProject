using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.Staff.Delete
{
    public class DeleteStaffHandler : IRequestHandler<DeleteStaffRequest, DeleteStaffResponse>
    {
        readonly IStaffWriteRepository _staffWriteRepository;
        public DeleteStaffHandler(IStaffWriteRepository staffWriteRepository)
        {
            _staffWriteRepository = staffWriteRepository;
        }

        public async Task<DeleteStaffResponse> Handle(DeleteStaffRequest request, CancellationToken cancellationToken)
        {
            await _staffWriteRepository.SoftDeleteAsync(request.Id);
            await _staffWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
