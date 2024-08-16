using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class LeaveWriteRepository : WriteRepository<BaseProjectDbContext, Leave>, ILeaveWriteRepository
    {
        public LeaveWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
