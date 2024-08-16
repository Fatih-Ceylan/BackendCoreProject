using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.MailCredential.GetById
{
    public class GetByIdMailCredentialRequest: IRequest<GetByIdMailCredentialResponse>
    {
        public string Id { get; set; }
    }
}