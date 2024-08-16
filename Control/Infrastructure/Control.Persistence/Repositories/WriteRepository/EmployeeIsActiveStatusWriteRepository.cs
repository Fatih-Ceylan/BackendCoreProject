using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class EmployeeIsActiveStatusWriteRepository : T.WriteRepository<BaseProjectDbContext, Employee>, IEmployeeIsActiveStatusWriteRepository
    {
        public EmployeeIsActiveStatusWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
