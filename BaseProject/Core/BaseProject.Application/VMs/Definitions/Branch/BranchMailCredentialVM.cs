using BaseProject.Application.VMs.Definitions.MailCredential;
using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Definitions.Branch
{
    public class BranchMailCredentialVM: BaseVM
    {
        public string Name { get; set; }

        public MailCredentialUpdateVM? MailCredential { get; set; }

    }
}