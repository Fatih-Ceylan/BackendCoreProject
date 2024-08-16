using MediatR;

namespace Card.Application.Features.Queries.Definitions.SocialMediaUrl.GetById
{
    public class GetByIdSocialMediaUrlRequest : IRequest<GetByIdSocialMediaUrlResponse>
    {
        public string Id { get; set; }
    }
}
