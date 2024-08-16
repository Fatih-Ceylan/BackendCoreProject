using Utilities.Core.UtilityDomain.Entities.Files;

namespace GCrm.Domain.Entities.Definitions.ProjectManagement.Projects.Files
{
    public class ProjectFiles : AppFile
    {
        public ICollection<Project> Projects { get; set; }
    }
}
