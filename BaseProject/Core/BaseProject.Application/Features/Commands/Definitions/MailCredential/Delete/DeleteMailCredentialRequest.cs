using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.MailCredential.Delete
{
    public class DeleteMailCredentialRequest: IRequest<DeleteMailCredentialResponse>
    {
        public string Id { get; set; }

    }
}