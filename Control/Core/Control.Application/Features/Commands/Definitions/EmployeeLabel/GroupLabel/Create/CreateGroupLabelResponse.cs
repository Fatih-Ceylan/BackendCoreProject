using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Create
{
    public class CreateLabelGroupResponse
    {
        public List<GroupEmployeeLabelVM> Employees { get; set; }
        public string Message { get; set; }
    }
}
