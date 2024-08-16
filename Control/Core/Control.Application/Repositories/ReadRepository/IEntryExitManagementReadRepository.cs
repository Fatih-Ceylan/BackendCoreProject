using BaseProject.Domain.Entities.GControl.Definitions;
using Utilities.Core.UtilityApplication.Interfaces;

namespace GControl.Application.Repositories.ReadRepository
{
    public interface IEntryExitManagementReadRepository : IReadRepository<EntryExitManagement>
    {
        Task<string> GetLocationIdByEmployeeId(string employeeId);
    }
}
