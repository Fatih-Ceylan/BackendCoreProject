using Platform.Application.VMs.Definitions.License;

namespace Platform.Application.Features.Commands.Definitions.License.Create
{
    public class CreateLicenseResponse
    {
        public CreateLicenseResponseVM License { get; set; }

        public List<string> MessageList { get; set; }
    }
}