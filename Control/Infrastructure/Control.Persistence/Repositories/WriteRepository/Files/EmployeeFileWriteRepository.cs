using BaseProject.Domain.Entities.GControl.Definitions.Files;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository.Files
{
    public class EmployeeFileWriteRepository : WriteRepository<BaseProjectDbContext, EmployeeFile>, IEmployeeFileWriteRepository
    {
        public EmployeeFileWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
