using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{

    public class EmployeeTypeReadRepository : ReadRepository<BaseProjectDbContext, EmployeeType>, IEmployeeTypeReadRepository
    {
        public EmployeeTypeReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
