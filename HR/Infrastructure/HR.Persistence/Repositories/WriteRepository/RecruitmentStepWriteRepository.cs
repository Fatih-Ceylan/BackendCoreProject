using BaseProject.Domain.Entities.HR.Recruitment.Recruit;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class RecruitmentStepWriteRepository : WriteRepository<BaseProjectDbContext, RecruitmentStep>, IRecruitmentStepWriteRepository
    {
        public RecruitmentStepWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
