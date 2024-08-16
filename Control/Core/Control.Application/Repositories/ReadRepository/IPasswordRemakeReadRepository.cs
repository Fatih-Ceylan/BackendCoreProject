using BaseProject.Domain.Entities.GControl.Definitions;
using Utilities.Core.UtilityApplication.Interfaces;

namespace GControl.Application.Repositories.ReadRepository
{
    public interface IPasswordRemakeReadRepository : IReadRepository<PasswordRemake>
    {
        Task<PasswordRemake> GetByTokenAsync(string token, bool tracking = true);
    }
}
