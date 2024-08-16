using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class StaffFieldWriteRepository : T.WriteRepository<BaseProjectDbContext, StaffField>, IStaffFieldWriteRepository
    {
        public StaffFieldWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
