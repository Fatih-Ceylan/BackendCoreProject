using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class StaffContactWriteRepository : T.WriteRepository<BaseProjectDbContext, StaffContact>, IStaffContactWriteRepository
    {
        public StaffContactWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
