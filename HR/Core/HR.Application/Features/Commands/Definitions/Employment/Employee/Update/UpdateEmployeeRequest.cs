using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Employee.Update
{
    public class UpdateEmployeeRequest : IRequest<UpdateEmployeeResponse>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? Token { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? HireDate { get; set; }

        public float? Salary { get; set; }

        public string? CompanyId { get; set; }

        public string? BranchId { get; set; }

        public string? DepartmentId { get; set; }

        public string? AppellationId { get; set; }

        public string? ManagedDepartmentId { get; set; }

        public string? ManagerId { get; set; }
    }
}
