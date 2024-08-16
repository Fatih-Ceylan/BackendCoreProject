using BaseProject.Domain.Entities.HR.Recruitment.Recruit;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class RecruitmentProcessReadRepository : ReadRepository<BaseProjectDbContext, RecruitmentProcess>
    {
        public RecruitmentProcessReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
