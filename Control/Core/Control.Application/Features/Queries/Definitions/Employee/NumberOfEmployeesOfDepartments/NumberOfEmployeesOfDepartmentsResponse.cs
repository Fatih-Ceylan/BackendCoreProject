using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Employee.NumberOfEmployeesOfDepartments
{
    public class NumberOfEmployeesOfDepartmentsResponse
    {
        public int TotalCount { get; set; }

        public List<GroupEmployeeVM> Employees { get; set; }
    }
}
