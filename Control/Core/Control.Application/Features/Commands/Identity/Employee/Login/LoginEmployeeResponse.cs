namespace GControl.Application.Features.Commands.Identity.Employee.Login
{
    public class LoginEmployeeResponse
    {
        
        public CommandResponse CommandResponse { get; internal set; }
        public UserResponse UserResponse { get; internal set; }
    }
    public class UserResponse
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Token { get; set; }
        public string LocationId { get; set; }
    }
    public class CommandResponse
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }

   
}
