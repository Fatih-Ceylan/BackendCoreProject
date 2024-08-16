using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Commands.Identity.Employee.ChangePassword
{
    public class ChangePasswordResponse
    {
        public EmployeeVM Employee { get; set; }
        public string Message { get; set; }
    }
}
