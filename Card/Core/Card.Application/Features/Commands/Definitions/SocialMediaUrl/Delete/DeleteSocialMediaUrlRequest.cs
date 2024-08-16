using MediatR;

namespace Card.Application.Features.Commands.Definitions.SocialMediaUrl.Delete
{
    public class DeleteSocialMediaUrlRequest : IRequest<DeleteSocialMediaUrlResponse>
    {
        public string Id { get; set; }
    }
}
