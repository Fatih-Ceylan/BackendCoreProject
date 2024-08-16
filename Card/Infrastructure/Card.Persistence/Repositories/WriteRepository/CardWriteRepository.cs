using T=BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class CardWriteRepository : WriteRepository<BaseProjectDbContext, T.Card>, ICardWriteRepository
    {
        public CardWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
