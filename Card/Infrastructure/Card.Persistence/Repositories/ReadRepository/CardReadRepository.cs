using T=BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.ReadRepository
{
    public class CardReadRepository : ReadRepository<BaseProjectDbContext, T.Card>, ICardReadRepository
    {
        public CardReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
