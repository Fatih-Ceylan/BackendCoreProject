namespace Platform.Application.Features.Queries.Definitions.Company.GetByUrlPath
{
    public class GetByUrlPathCompanyResponse
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? LogoPath { get; set; }

        public string? UrlPath { get; set; }

        public string? Message { get; set; }
    }
}