using MediatR;

namespace Card.Application.Features.Commands.Identity.Staff.ForgotPasswordSendMail
{
    public class ForgotPasswordSendMailRequest : IRequest<ForgotPasswordSendMailResponse>
    {
        public string Email { get; set; }
    }
}
