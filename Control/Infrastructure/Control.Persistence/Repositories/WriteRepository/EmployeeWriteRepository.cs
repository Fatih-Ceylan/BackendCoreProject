using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class EmployeeWriteRepository : T.WriteRepository<BaseProjectDbContext, Employee>, IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
