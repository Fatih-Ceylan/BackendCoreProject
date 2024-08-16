using BaseProject.Application.VMs.Definitions;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetMainDepartments
{
    public class GetMainDepartmentsResponse
    {
        public int TotalCount { get; set; }

        public List<DepartmentVM> MainDepartments { get; set; }
    }
}