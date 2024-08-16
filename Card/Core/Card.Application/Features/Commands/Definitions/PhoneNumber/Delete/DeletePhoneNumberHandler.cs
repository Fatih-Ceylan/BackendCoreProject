using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.PhoneNumber.Delete
{
    public class DeletePhoneNumberHandler : IRequestHandler<DeletePhoneNumberRequest, DeletePhoneNumberResponse>
    {
        readonly IPhoneNumberWriteRepository _phoneNumberWriteRepository;

        public DeletePhoneNumberHandler(IPhoneNumberWriteRepository phoneNumberWriteRepository)
        {
            _phoneNumberWriteRepository = phoneNumberWriteRepository;
        }

        public async Task<DeletePhoneNumberResponse> Handle(DeletePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            await _phoneNumberWriteRepository.SoftDeleteAsync(request.Id);
            await _phoneNumberWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
