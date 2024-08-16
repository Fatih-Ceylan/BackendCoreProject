using BaseProject.Domain.Entities.NLLogistics.Definitions;
using BaseProject.Persistence.Contexts;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace NLLogistics.Persistence.Repositories.WriteRepositories.Definitions
{
    public class VoyageWriteRepository: WriteRepository<BaseProjectDbContext, Voyage>, IVoyageWriteRepository
    {
        public VoyageWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
