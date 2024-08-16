using BaseProject.Application.VMs.Definitions.Branch;
using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Definitions.Company
{
    public class CompanyMailCredentialVM: BaseVM
    {
        public string Name { get; set; }

        public int BranchCount { get; set; }

        public List<BranchMailCredentialVM>? Branches { get; set; }

    }
}
