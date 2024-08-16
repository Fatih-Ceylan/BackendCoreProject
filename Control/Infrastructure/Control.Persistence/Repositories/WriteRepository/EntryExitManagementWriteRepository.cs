using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;
namespace GControl.Persistence.Repositories.WriteRepository
{
    public class EntryExitManagementWriteRepository : T.WriteRepository<BaseProjectDbContext, EntryExitManagement>, IEntryExitManagementWriteRepository
    {
        public EntryExitManagementWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
