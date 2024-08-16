namespace Card.Application.VMs
{
    public class CustomSocialMediaUrlVM
    {
        public List<SocialMediaUrlVM>? Instagrams { get; set; }
        public List<SocialMediaUrlVM>? Linkedins { get; set; }
        public List<SocialMediaUrlVM>? WebSites { get; set; }
        public List<SocialMediaUrlVM>? Facebooks { get; set; }
        public List<SocialMediaUrlVM>? Pinterests { get; set; }
        public List<SocialMediaUrlVM>? Twitters { get; set; }
        public string? UrlPath { get; set; }
        public string? SocialMediaId { get; set; }
        public string? SocialMediaName { get; set; }

    }
}
