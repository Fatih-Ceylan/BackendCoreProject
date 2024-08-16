using BaseProject.Application.VMs.Definitions;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetDropdownList
{
    public class GetDropdownListDepartmentResponse
    {
        public List<DepartmentDropdownListVM> DepartmentDropdownList { get; set; }
    }
}
