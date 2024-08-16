using BaseProject.Application.Repositories.WriteRepository.Identity;
using BaseProject.Domain.Entities.Identity.File;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.WriteRepository.Identity
{
    public class AppUserFileWriteRepository : WriteRepository<BaseProjectDbContext, AppUserFile>, IAppUserFileWriteRepository
    {
        public AppUserFileWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}