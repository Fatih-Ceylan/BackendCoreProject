using BaseProject.Application.VMs.Definitions.MailCredential;

namespace BaseProject.Application.Features.Queries.Definitions.MailCredential.GetAll
{
    public class GetAllMailCredentialResponse
    {
        public int TotalCount { get; set; }

        public List<MailCredentialVM> MailCredentials { get; set; }
    }
}