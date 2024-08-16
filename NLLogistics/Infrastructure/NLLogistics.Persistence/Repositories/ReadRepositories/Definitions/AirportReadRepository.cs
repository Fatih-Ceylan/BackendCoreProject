using BaseProject.Domain.Entities.NLLogistics.Definitions;
using BaseProject.Persistence.Contexts;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace NLLogistics.Persistence.Repositories.ReadRepositories.Definitions
{
    public class AirportReadRepository: ReadRepository<BaseProjectDbContext, Airport>, IAirportReadRepository
    {
        public AirportReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
