using BaseProject.Domain.Entities.HR.Recruitment.Recruit;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class RecruitmentProcessWriteRepository : WriteRepository<BaseProjectDbContext, RecruitmentProcess>, IRecruitmentProcessWriteRepository
    {
        public RecruitmentProcessWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
