using BaseProject.Domain.Entities.Card.Definitions.Files;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.ReadRepository.Files
{
    public class StaffFileReadRepository : ReadRepository<BaseProjectDbContext, StaffFile>, IStaffFileReadRepository
    {
        public StaffFileReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
