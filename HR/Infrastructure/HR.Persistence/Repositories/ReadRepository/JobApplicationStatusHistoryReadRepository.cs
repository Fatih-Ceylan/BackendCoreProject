using BaseProject.Domain.Entities.HR.Recruitment.Applications;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class JobApplicationStatusHistoryReadRepository : ReadRepository<BaseProjectDbContext, JobApplicationStatusHistory>, IJobApplicationStatusHistoryReadRepository
    {
        public JobApplicationStatusHistoryReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
