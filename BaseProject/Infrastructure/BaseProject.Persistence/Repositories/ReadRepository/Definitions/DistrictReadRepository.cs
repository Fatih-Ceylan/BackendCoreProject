using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Definitions
{
    public class DistrictReadRepository: ReadRepository<BaseProjectDbContext,District>, IDistrictReadRepository
    {
        public DistrictReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}