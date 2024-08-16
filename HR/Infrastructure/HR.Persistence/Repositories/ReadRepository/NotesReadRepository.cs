using BaseProject.Domain.Entities.HR.Recruitment.Recruit;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class NotesReadRepository : ReadRepository<BaseProjectDbContext, Notes>, INotesReadRepository
    {
        public NotesReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
