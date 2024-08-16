using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class EducationInfoWriteRepository : WriteRepository<BaseProjectDbContext, EducationInfo>, IEducationInfoWriteRepository
    {
        public EducationInfoWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
