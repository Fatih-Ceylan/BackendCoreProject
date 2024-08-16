using BaseProject.Application.DTOs.Definitions.Department;

namespace BaseProject.Application.Abstractions.Services.Definitions
{
    public interface IDepartmentService
    {
        DepartmentDTO? GetDepartmentById(string id);
        
    }
}