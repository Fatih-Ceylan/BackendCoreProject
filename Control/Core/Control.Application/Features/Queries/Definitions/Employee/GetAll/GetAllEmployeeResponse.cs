using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Employee.GetAll
{
    public class GetAllEmployeeResponse
    {
        public int TotalCount { get; set; }

        public List<EmployeeNewBaseVM> Employees { get; set; }
    }
}
