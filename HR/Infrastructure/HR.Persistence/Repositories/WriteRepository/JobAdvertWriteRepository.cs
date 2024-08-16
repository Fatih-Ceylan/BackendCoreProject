using BaseProject.Domain.Entities.HR.Recruitment.Jobs;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class JobAdvertWriteRepository : WriteRepository<BaseProjectDbContext, JobAdvert>, IJobAdvertWriteRepository
    {
        public JobAdvertWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
