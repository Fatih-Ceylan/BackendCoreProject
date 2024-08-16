using BaseProject.Domain.Entities.HR.Recruitment.Applications;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class JobApplicationWriteRepository : WriteRepository<BaseProjectDbContext, JobApplication>, IJobApplicationWriteRepository
    {
        public JobApplicationWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
