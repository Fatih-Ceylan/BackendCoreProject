using BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class ProjectTypeWriteRepository : WriteRepository<BaseProjectDbContext, ProjectType>, IProjectTypeWriteRepository
    {
        public ProjectTypeWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
