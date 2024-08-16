namespace Card.Application.Features.Commands.Definitions.SocialMediaUrl.Create
{
    public class CreateSocialMediaUrlResponse
    {
        public string Id { get; set; }
        public string SocialMediaName { get; set; }
        public string UrlPath { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Message { get; set; }
    }
}
