using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.SocialMedia.GetAll
{
    public class GetAllSocialMediaHandler : IRequestHandler<GetAllSocialMediaRequest, GetAllSocialMediaResponse>
    {
        readonly ISocialMediaReadRepository _socialMediaReadRepository;
        public GetAllSocialMediaHandler(ISocialMediaReadRepository socialMediaReadRepository)
        {
            _socialMediaReadRepository = socialMediaReadRepository;
        }
        public Task<GetAllSocialMediaResponse> Handle(GetAllSocialMediaRequest request, CancellationToken cancellationToken)
        {
            var query = _socialMediaReadRepository.GetAllDeletedStatusDesc(false)
                .Select(c => new SocialMediaVM
                {
                    Id = c.Id.ToString(),
                    CreatedDate = c.CreatedDate,
                    Name = c.Name,
                });

            var totalCount = query.Count();
            var socialMedias = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllSocialMediaResponse
            {
                TotalCount = totalCount,
                SocialMedias = socialMedias,
            });
        }
    }
}
