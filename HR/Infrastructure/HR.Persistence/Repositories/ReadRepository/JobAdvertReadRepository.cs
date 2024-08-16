using BaseProject.Domain.Entities.HR.Recruitment.Jobs;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class JobAdvertReadRepository : ReadRepository<BaseProjectDbContext, JobAdvert>, IJobAdvertReadRepository
    {
        public JobAdvertReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
