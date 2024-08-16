using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class LeaveTypeReadRepository : ReadRepository<BaseProjectDbContext, LeaveType>, ILeaveTypeReadRepository
    {
        public LeaveTypeReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
