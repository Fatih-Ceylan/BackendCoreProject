using MediatR;

namespace Card.Application.Features.Commands.Definitions.SocialMediaUrl.Update
{
    public class UpdateSocialMediaUrlRequest : IRequest<UpdateSocialMediaUrlResponse>
    {
        public string Id { get; set; }
        public string? UrlPath { get; set; }
        public string? SocialMediaId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
