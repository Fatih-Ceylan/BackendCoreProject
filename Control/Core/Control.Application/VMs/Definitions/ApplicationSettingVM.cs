using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class ApplicationSettingVM : BaseVM
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAccepted { get; set; }
        public Company Company { get; set; }
    }
}
