using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Definitions
{
    public class CompanyReadRepository : ReadRepository<BaseProjectDbContext, Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(BaseProjectDbContext context) : base(context)
        {
        }

    }
}
