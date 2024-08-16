using BaseProject.Domain.Entities.NLLogistics.Definitions;
using BaseProject.Persistence.Contexts;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace NLLogistics.Persistence.Repositories.ReadRepositories.Definitions
{
    public class VoyageReadRepository : ReadRepository<BaseProjectDbContext, Voyage>, IVoyageReadRepository
    {
        public VoyageReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
