using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.StaffContact.Delete
{
    public class DeleteStaffContactHandler : IRequestHandler<DeleteStaffContactRequest, DeleteStaffContactResponse>
    {
        readonly IStaffContactWriteRepository _staffContactWriteRepository;
        public async Task<DeleteStaffContactResponse> Handle(DeleteStaffContactRequest request, CancellationToken cancellationToken)
        {
            await _staffContactWriteRepository.SoftDeleteAsync(request.Id);
            await _staffContactWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
