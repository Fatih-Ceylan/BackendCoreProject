using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class ShiftManagementWriteRepository : T.WriteRepository<BaseProjectDbContext, ShiftManagement>, IShiftManagementWriteRepository
    {
        public ShiftManagementWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
