using BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Department.GetAll
{
    public class GetAllDepartmentResponse
    {
        public int TotalCount { get; set; }

        public List<DepartmentDDLVM> Departments { get; set; }
    }
}
