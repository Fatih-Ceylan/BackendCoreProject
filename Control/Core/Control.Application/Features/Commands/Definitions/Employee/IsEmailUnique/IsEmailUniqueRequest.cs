using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Employee.IsEmailUnique
{
    public class IsEmailUniqueRequest : IRequest<IsEmailUniqueResponse>
    {
        public string Email { get; set; }
    }
}
