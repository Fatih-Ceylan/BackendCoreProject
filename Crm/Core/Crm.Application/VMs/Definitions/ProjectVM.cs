using BaseProject.Domain.Entities.GCrm.Enums;
using GCrm.Application.VMs.Definitions.Files;
using Utilities.Core.UtilityApplication.VMs;

namespace GCrm.Application.VMs.Definitions
{
    public class ProjectVM : BaseVM
    {
        public string ProjectName { get; set; } //proje adı
        public string ProjectManagerId { get; set; }
        public string ProjectTeamId { get; set; }
        public string CustomerId { get; set; }
        public string ProjectTypeId { get; set; }
        public string ProjectStatuesId { get; set; }
        public DateTime ProjectStartDate { get; set; } //başlangıç tarihi
        public DateTime ProjectFinishDate { get; set; } //bitiş tarihi         
        public ProjectPriorityEnum ProjectPriorityEnum { get; set; } //proje öncelik
        public string Description { get; set; }
        public List<ProjectFileVM>? ProjectFiles { get; set; }
    }
}
