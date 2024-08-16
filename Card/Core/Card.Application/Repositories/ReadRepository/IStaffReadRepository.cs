using BaseProject.Domain.Entities.Card.Definitions;
using Utilities.Core.UtilityApplication.Interfaces;

namespace Card.Application.Repositories.ReadRepository
{
    public interface IStaffReadRepository : IReadRepository<Staff>
    {
        Task<Staff> GetByEmailAsync(string email, bool tracking = true);
        Task<Staff> GetByUserNameAsync(string userName, bool tracking = true);
    }
}
