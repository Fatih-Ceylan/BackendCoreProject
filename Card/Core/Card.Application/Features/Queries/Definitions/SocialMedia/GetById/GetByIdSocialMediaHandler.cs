using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.SocialMedia.GetById
{
    public class GetByIdSocialMediaHandler : IRequestHandler<GetByIdSocialMediaRequest, GetByIdSocialMediaResponse>
    {
        readonly ISocialMediaReadRepository _socialMediaReadRepository;
        public GetByIdSocialMediaHandler(ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
        }

        public async Task<GetByIdSocialMediaResponse> Handle(GetByIdSocialMediaRequest request, CancellationToken cancellationToken)
        {
            var socialMedia = _socialMediaReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new SocialMediaVM
                            {
                                Id = c.Id.ToString(),
                                Name = c.Name,
                                CreatedDate = c.CreatedDate
                            }).FirstOrDefault();

            return new()
            {
                SocialMedia = socialMedia
            };
        }
    }
}
