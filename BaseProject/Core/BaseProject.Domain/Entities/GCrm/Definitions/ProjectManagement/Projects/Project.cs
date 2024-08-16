using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects.Files;
using BaseProject.Domain.Entities.GCrm.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; } //proje adı
        public Guid ProjectManagerId { get; set; }
        public Guid ProjectTeamId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProjectTypeId { get; set; }
        public Guid ProjectStatuesId { get; set; }
        public DateTime ProjectStartDate { get; set; } //başlangıç tarihi
        public DateTime ProjectFinishDate { get; set; } //bitiş tarihi         
        public ProjectPriorityEnum ProjectPriorityEnum { get; set; } //proje öncelik
        public string Description { get; set; }
        public ProjectManager ProjectManager { get; set; } //proje yonetıcisi
        public ProjectTeam ProjectTeam { get; set; } // proje ekibi
        public Customer Customer { get; set; }
        public ProjectType ProjectType { get; set; }
        public ProjectStatues ProjectStatues { get; set; }
        public ICollection<ProjectFiles> ProjectFiles { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
