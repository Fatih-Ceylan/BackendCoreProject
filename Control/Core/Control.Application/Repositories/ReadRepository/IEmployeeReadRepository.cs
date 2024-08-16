using BaseProject.Domain.Entities.GControl.Definitions;
using Utilities.Core.UtilityApplication.Interfaces;

namespace GControl.Application.Repositories.ReadRepository
{
    public interface IEmployeeReadRepository : IReadRepository<Employee>
    {
        Task<Employee> GetByEmailAsync(string email, bool tracking = true);
    }
}
