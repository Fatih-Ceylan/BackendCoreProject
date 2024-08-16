namespace BaseProject.Application.VMs.Definitions.MailCredential
{
    public class MailCredentialUpdateVM
    {
        public string Id { get; set; }

        public string From { get; set; }

        public string DisplayName { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        public bool EnableSsl { get; set; }

        public bool IsActive { get; set; }
    }
}
