using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class PasswordRemakeWriteRepository : T.WriteRepository<BaseProjectDbContext, PasswordRemake>, IPasswordRemakeWriteRepository
    {
        public PasswordRemakeWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
