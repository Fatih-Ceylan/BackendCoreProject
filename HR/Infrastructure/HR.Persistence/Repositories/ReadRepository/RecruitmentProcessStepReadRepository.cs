using BaseProject.Domain.Entities.HR.Recruitment.Recruit;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class RecruitmentProcessStepReadRepository : ReadRepository<BaseProjectDbContext, RecruitmentProcessStep>
    {
        public RecruitmentProcessStepReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
