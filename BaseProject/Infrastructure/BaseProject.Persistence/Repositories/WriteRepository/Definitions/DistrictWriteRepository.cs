using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.WriteRepository.Definitions
{
    public class DistrictWriteRepository: WriteRepository<BaseProjectDbContext, District>, IDistrictWriteRepository
    {
        public DistrictWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}