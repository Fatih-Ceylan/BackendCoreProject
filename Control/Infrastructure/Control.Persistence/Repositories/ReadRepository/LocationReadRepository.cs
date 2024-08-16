using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class LocationReadRepository : ReadRepository<BaseProjectDbContext, Location>, ILocationReadRepository
    {
        public LocationReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
