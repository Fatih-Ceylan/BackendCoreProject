using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EmployeeType.GetAll
{
    public class GetAllEmployeeTypeResponse
    {
        public int TotalCount { get; set; }

        public List<EmployeeTypeVM> EmployeeTypes { get; set; }
    }
}
