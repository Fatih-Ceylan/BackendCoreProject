using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class EducationInfoReadRepository : ReadRepository<BaseProjectDbContext, EducationInfo>, IEducationInfoReadRepository
    {
        public EducationInfoReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
