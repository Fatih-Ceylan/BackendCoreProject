using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.WriteRepository.Definitions
{
    public class CompanyAddressWriteRepository : WriteRepository<BaseProjectDbContext, CompanyAddress>, ICompanyAddressWriteRepository
    {
        public CompanyAddressWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}