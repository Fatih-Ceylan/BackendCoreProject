using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class SocialMediaUrlWriteRepository : T.WriteRepository<BaseProjectDbContext, SocialMediaUrl>, ISocialMediaUrlWriteRepository
    {
        public SocialMediaUrlWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
