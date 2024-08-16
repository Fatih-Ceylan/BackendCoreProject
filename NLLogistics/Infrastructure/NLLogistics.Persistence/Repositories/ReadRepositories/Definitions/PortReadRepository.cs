using BaseProject.Domain.Entities.NLLogistics.Definitions;
using BaseProject.Persistence.Contexts;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace NLLogistics.Persistence.Repositories.ReadRepositories.Definitions
{
    public class PortReadRepository: ReadRepository<BaseProjectDbContext,Port>, IPortReadRepository
    {
        public PortReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
