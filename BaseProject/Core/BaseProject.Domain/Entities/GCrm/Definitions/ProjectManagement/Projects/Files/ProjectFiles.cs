using Utilities.Core.UtilityDomain.Entities.Files;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects.Files
{
    public class ProjectFiles : AppFile
    {
        public ICollection<Project> Projects { get; set; }
    }
}
