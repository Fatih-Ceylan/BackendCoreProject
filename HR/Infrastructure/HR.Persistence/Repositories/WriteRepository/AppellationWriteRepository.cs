using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class AppellationWriteRepository : WriteRepository<BaseProjectDbContext, Appellation>, IAppellationWriteRepository
    {
        public AppellationWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
