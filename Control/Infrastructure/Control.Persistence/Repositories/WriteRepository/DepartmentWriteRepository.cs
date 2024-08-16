using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class DepartmentWriteRepository : T.WriteRepository<BaseProjectDbContext, Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
