using BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Abstractions.Services
{
    public interface IBaseProjectService
    {
        Task<DepartmentResponse> GetDepartments(string accessToken, string routeName);
    }
}
