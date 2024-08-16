using MediatR;

namespace Platform.Application.Features.Commands.Outbounds.SendEmailToContacts
{
    public class SendEmailToContactsRequest : IRequest<SendEmailToContactsResponse>
    {
        public string Email { get; set; }
    }
}