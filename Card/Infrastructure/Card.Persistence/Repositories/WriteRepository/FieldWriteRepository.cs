using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class FieldWriteRepository : T.WriteRepository<BaseProjectDbContext, Field>, IFieldWriteRepository
    {
        public FieldWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
