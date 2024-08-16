using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Domain.Entities.Definitions;
using BaseProject.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace BaseProject.Persistence.Repositories.ReadRepository.Definitions
{
    public class MailCredentialReadRepository : ReadRepository<BaseProjectDbContext, MailCredential>, IMailCredentialReadRepository
    {
        public MailCredentialReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
