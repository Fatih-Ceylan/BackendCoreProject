using BaseProject.Domain.Entities.HR.Recruitment.Recruit;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class RecruitmentStepReadRepository : ReadRepository<BaseProjectDbContext, RecruitmentStep>
    {
        public RecruitmentStepReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
