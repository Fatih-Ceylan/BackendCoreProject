using BaseProject.Application.Repositories.ReadRepository.Definitions.Files;
using BaseProject.Domain.Entities.Definitions.Files;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Definitions.Files
{
    public class CompanyFileReadRepository : ReadRepository<BaseProjectDbContext, CompanyFile>, ICompanyFileReadRepository
    {
        public CompanyFileReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
