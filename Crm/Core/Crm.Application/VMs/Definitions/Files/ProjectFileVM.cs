using Utilities.Core.UtilityApplication.VMs;

namespace GCrm.Application.VMs.Definitions.Files
{
    public class ProjectFileVM : BaseVM
    {
        public string Id { get; set; }
        public string PathOrContainerName { get; set; }
        public string FileName { get; set; }
        public string Storage { get; set; }
        public string ProjectId { get; set; }
    }
}
