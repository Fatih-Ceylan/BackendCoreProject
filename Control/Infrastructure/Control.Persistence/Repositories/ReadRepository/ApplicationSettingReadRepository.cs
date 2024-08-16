using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class ApplicationSettingReadRepository : ReadRepository<BaseProjectDbContext, ApplicationSetting>, IApplicationSettingReadRepository
    {
        public ApplicationSettingReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
