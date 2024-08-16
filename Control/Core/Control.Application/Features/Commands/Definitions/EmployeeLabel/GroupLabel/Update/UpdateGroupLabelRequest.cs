using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Update
{
    public class UpdateGroupLabelRequest : IRequest<UpdateGroupLabelResponse>
    {
        public List<string> EmployeesId { get; set; } = new List<string>();
        public List<string> EmployeeLabelsId { get; set; } = new List<string>();
    }
}
