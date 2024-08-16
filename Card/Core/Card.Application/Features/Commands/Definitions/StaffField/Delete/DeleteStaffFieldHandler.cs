using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.StaffField.Delete
{
    public class DeleteStaffFieldHandler : IRequestHandler<DeleteStaffFieldRequest, DeleteStaffFieldResponse>
    {
        readonly IStaffFieldWriteRepository _staffFieldWriteRepository;

        public DeleteStaffFieldHandler(IStaffFieldWriteRepository staffFieldWriteRepository)
        {
            _staffFieldWriteRepository = staffFieldWriteRepository;
        }

        public async Task<DeleteStaffFieldResponse> Handle(DeleteStaffFieldRequest request, CancellationToken cancellationToken)
        {
            await _staffFieldWriteRepository.SoftDeleteAsync(request.Id);
            await _staffFieldWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
