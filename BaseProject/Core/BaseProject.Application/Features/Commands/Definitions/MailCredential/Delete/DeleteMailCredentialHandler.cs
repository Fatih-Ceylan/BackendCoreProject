using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.MailCredential.Delete
{
    public class DeleteMailCredentialHandler : IRequestHandler<DeleteMailCredentialRequest, DeleteMailCredentialResponse>
    {
        readonly IMailCredentialWriteRepository _mailCredentialWriteRepository;

        public DeleteMailCredentialHandler(IMailCredentialWriteRepository mailCredentialWriteRepository)
        {
            _mailCredentialWriteRepository = mailCredentialWriteRepository;
        }

        public async Task<DeleteMailCredentialResponse> Handle(DeleteMailCredentialRequest request, CancellationToken cancellationToken)
        {
            await _mailCredentialWriteRepository.SoftDeleteAsync(request.Id);
            await _mailCredentialWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}