using BaseProject.Application.VMs.Definitions;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetAll
{
    public class GetAllDepartmentResponse
    {
        public int TotalCount { get; set; }

        public List<DepartmentVM> Departments { get; set; }
    }
}