using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class LocationWriteRepository : T.WriteRepository<BaseProjectDbContext, Location>, ILocationWriteRepository
    {
        public LocationWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
