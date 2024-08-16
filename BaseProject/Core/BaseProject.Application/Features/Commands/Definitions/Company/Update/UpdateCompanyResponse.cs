namespace BaseProject.Application.Features.Commands.Definitions.Company.Update
{
    public class UpdateCompanyResponse
    {
        public string Id { get; set; }

        public string? MasterCompanyIdFromPlatform { get; set; }

        public string? MainCompanyId { get; set; }

        public string? LogoPath { get; set; }

        public string Name { get; set; }

        public string AuthorizedFullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FaxNo { get; set; }

        public string? Email { get; set; }

        public string? WebAddress { get; set; }

        public string? TaxOffice { get; set; }

        public string? TaxNo { get; set; }

        public string? TradeRegisterNo { get; set; }

        public string? SocialSecurityNo { get; set; }

        public string? MersisNo { get; set; }

        public List<string> MessageList { get; set; }
    }
}