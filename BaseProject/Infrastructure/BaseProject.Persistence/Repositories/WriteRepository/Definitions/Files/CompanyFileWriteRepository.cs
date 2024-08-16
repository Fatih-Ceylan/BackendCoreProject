using BaseProject.Application.Repositories.WriteRepository.Definitions.Files;
using BaseProject.Domain.Entities.Definitions.Files;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.WriteRepository.Definitions.Files
{
    public class CompanyFileWriteRepository : WriteRepository<BaseProjectDbContext, CompanyFile>, ICompanyFileWriteRepository
    {
        public CompanyFileWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}