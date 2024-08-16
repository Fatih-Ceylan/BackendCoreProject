using MediatR;

namespace GControl.Application.Features.Commands.Identity.Employee.SendPasswordWithMail
{
    public class SendPasswordWithMailRequest : IRequest<SendPasswordWithMailResponse>
    {
        public string Email { get; set; }
    }
}
