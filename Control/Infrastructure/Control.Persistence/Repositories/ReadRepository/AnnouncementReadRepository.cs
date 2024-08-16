using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class AnnouncementReadRepository : ReadRepository<BaseProjectDbContext, Announcement>, IAnnouncementReadRepository
    {
        public AnnouncementReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
