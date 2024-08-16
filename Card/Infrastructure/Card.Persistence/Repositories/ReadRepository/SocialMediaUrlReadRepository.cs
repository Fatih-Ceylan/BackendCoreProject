using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.ReadRepository
{
    public class SocialMediaUrlReadRepository : ReadRepository<BaseProjectDbContext, SocialMediaUrl>, ISocialMediaUrlReadRepository
    {
        public SocialMediaUrlReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
