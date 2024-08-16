using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class EntryExitManagementReadRepository : ReadRepository<BaseProjectDbContext, EntryExitManagement>, IEntryExitManagementReadRepository
    {
        public EntryExitManagementReadRepository(BaseProjectDbContext context) : base(context)
        {
        }

        public Task<string> GetLocationIdByEmployeeId(string employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
