using HR.Application.VMs.Definitions;

namespace HR.Application.Features.Queries.Definitions.Employee.GetAll
{
    public class GetAllEmployeeResponse
    {
        public int TotalCount { get; set; }

        public List<EmployeeVM> Employees { get; set; }
    }
}
