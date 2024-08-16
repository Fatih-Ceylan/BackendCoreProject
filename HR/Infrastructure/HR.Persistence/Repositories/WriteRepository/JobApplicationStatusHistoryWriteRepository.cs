using BaseProject.Domain.Entities.HR.Recruitment.Applications;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class JobApplicationStatusHistoryWriteRepository : WriteRepository<BaseProjectDbContext, JobApplicationStatusHistory>, IJobApplicationStatusHistoryWriteRepository
    {
        public JobApplicationStatusHistoryWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
