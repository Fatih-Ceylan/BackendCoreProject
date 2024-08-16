using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class EmployeeIsActiveStatusReadRepository : ReadRepository<BaseProjectDbContext, Employee>, IEmployeeIsActiveStatusReadRepository
    {
        public EmployeeIsActiveStatusReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
