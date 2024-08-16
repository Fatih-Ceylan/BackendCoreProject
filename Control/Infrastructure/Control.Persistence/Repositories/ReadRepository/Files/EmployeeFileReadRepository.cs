using BaseProject.Domain.Entities.GControl.Definitions.Files;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository.Files
{
    public class EmployeeFileReadRepository : ReadRepository<BaseProjectDbContext, EmployeeFile>, IEmployeeFileReadRepository
    {
        public EmployeeFileReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
