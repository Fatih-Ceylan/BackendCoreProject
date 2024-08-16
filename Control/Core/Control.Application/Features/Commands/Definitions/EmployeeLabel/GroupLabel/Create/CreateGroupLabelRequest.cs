using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Create
{
    public class CreateLabelGroupRequest : IRequest<CreateLabelGroupResponse>
    {
        public List<string> EmployeesId { get; set; } = new List<string>();
        public List<string> EmployeeLabelsId { get; set; } = new List<string>();
    }
}
