using BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public class ProjectManagerWriteRepository : WriteRepository<BaseProjectDbContext, ProjectManager>, IProjectManagerWriteRepository
    {
        public ProjectManagerWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
