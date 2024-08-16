using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class EmployeeLabelWriteRepository : T.WriteRepository<BaseProjectDbContext, EmployeeLabel>, IEmployeeLabelWriteRepository
    {
        public EmployeeLabelWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
