using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.SocialMediaUrl.GetAll
{
    public class GetAllSocialMediaUrlResponse
    {
        public int TotalCount { get; set; }

        public List<SocialMediaUrlVM> SocialMediaUrls { get; set; }
    }
}
