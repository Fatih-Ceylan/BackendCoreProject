using GCrm.Domain.Entities.Definitions.CustomerManagement.Customers;
using GCrm.Domain.Entities.Definitions.ProjectManagement.Projects.Files;
using GCrm.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ProjectManagement.Projects
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
    }
}
