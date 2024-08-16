using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class SocialMediaWriteRepository : T.WriteRepository<BaseProjectDbContext, SocialMedia>, ISocialMediaWriteRepository
    {
        public SocialMediaWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
