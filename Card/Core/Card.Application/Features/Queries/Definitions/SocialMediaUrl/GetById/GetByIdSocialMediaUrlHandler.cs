using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.SocialMediaUrl.GetById
{
    public class GetByIdSocialMediaUrlHandler : IRequestHandler<GetByIdSocialMediaUrlRequest, GetByIdSocialMediaUrlResponse>
    {
        readonly ISocialMediaUrlReadRepository _socialMediaUrlReadRepository;

        public GetByIdSocialMediaUrlHandler(ISocialMediaUrlReadRepository socialMediaUrlReadRepository)
        {
            _socialMediaUrlReadRepository = socialMediaUrlReadRepository;
        }

        public async Task<GetByIdSocialMediaUrlResponse> Handle(GetByIdSocialMediaUrlRequest request, CancellationToken cancellationToken)
        {
            var socialMediaUrl = _socialMediaUrlReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new SocialMediaUrlVM
                            {
                                Id = c.Id.ToString(),
                                CreatedDate = c.CreatedDate,
                                StaffName = c.Staff.Name,
                                SocialMediaName = c.SocialMedia.Name,
                                StaffId = c.StaffId.ToString(),
                                SocialMediaId = c.SocialMediaId.ToString(),
                                UrlPath = c.UrlPath,
                                BranchId = c.BranchId.ToString(),
                                BranchName = c.Branch.Name,
                                CompanyId = c.CompanyId.ToString(),
                                CompanyName = c.Branch.Company.Name

                            }).FirstOrDefault();

            return new()
            {
                SocialMediaUrl = socialMediaUrl
            };
        }
    }
}
