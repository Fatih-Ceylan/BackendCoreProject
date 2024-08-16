using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class PasswordRemakeWriteRepository : T.WriteRepository<BaseProjectDbContext, PasswordRemake>, IPasswordRemakeWriteRepository
    {
        public PasswordRemakeWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
