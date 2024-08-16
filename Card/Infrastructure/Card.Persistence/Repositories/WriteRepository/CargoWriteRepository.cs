using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class CargoWriteRepository : WriteRepository<BaseProjectDbContext, Cargo>, ICargoWriteRepository
    {
        public CargoWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
