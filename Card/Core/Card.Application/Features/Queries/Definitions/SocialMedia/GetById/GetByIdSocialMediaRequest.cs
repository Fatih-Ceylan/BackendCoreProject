using MediatR;

namespace Card.Application.Features.Queries.Definitions.SocialMedia.GetById
{
    public class GetByIdSocialMediaRequest : IRequest<GetByIdSocialMediaResponse>
    {
        public string Id { get; set; }
    }
}
