using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupEntryExit
{
    public class CreateGroupEntryExitRequest : IRequest<CreateGroupEntryExitResponse>
    {
        public List<string> EmployeeId { get; set; } = new List<string>();
        public bool IsRegistrationType { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}
