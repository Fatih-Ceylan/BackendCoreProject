using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.DeletingEmployeesLabels
{
    public class DeletingEmployeesLabelsResponse
    {
        public List<GroupEmployeeLabelVM> Employees { get; set; }
        public string Message { get; set; }
    }
}
