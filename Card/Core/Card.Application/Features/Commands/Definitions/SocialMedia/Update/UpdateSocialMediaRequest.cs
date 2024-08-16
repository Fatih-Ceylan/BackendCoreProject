using MediatR;

namespace Card.Application.Features.Commands.Definitions.SocialMedia.Update
{
    public class UpdateSocialMediaRequest : IRequest<UpdateSocialMediaResponse>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? UrlPath { get; set; }
    }
}
