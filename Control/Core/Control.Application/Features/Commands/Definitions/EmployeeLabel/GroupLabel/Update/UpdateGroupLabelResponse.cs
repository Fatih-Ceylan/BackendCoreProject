using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Update
{
    public class UpdateGroupLabelResponse
    {
        public List<GroupEmployeeLabelVM> Employees { get; set; }
        public string Message { get; set; }
    }
}
