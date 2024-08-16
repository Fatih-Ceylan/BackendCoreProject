using BaseProject.Domain.Entities.Card.Definitions.Files;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository.Files
{
    public class StaffFileWriteRepository : WriteRepository<BaseProjectDbContext, StaffFile>, IStaffFileWriteRepository
    {
        public StaffFileWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
