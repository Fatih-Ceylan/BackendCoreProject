using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.SocialMedia.GetAll
{
    public class GetAllSocialMediaResponse
    {
        public int TotalCount { get; set; }

        public List<SocialMediaVM> SocialMedias { get; set; }
    }
}
