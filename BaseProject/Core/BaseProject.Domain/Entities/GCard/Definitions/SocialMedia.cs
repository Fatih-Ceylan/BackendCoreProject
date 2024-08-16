using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class SocialMedia : BaseEntity
    {
        public string? Name { get; set; } 
        public ICollection<SocialMediaUrl> SocialMediaUrls { get; set; }
    }
}
