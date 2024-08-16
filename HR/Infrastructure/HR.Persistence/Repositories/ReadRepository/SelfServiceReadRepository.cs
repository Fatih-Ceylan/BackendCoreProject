using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class SelfServiceReadRepository : ReadRepository<BaseProjectDbContext, SelfService>
    {
        public SelfServiceReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
