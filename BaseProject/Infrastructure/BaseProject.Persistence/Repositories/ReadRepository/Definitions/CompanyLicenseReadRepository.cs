using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Definitions
{
    public class CompanyLicenseReadRepository: ReadRepository<BaseProjectDbContext, CompanyLicense>,ICompanyLicenseReadRepository
    {
        public CompanyLicenseReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}