using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.SocialMediaUrl.GetAll
{
    public class GetAllSocialMediaUrlHandler : IRequestHandler<GetAllSocialMediaUrlRequest, GetAllSocialMediaUrlResponse>
    {
        readonly ISocialMediaUrlReadRepository _socialMediaUrlReadRepository; 

        public GetAllSocialMediaUrlHandler(ISocialMediaUrlReadRepository socialMediaUrlReadRepository)
        {
            _socialMediaUrlReadRepository = socialMediaUrlReadRepository; 
        }

        public async Task<GetAllSocialMediaUrlResponse> Handle(GetAllSocialMediaUrlRequest request, CancellationToken cancellationToken)
        {
            var socialMediaQuery = _socialMediaUrlReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                socialMediaQuery = socialMediaQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                socialMediaQuery = socialMediaQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var socialMediaUrls = await socialMediaQuery.Select(s => new SocialMediaUrlVM
            {
                Id = s.Id.ToString(),
                CreatedDate = s.CreatedDate,
                StaffName = s.Staff.Name,
                SocialMediaName = s.SocialMedia.Name,
                StaffId = s.StaffId.ToString(),
                SocialMediaId = s.SocialMediaId.ToString(),
                UrlPath = s.UrlPath,
                BranchId = s.BranchId.ToString(),
                BranchName = s.Branch.Name,
                CompanyId = s.CompanyId.ToString(),
                CompanyName = s.Branch.Company.Name,

            }).ToListAsync(cancellationToken); 

            var totalCount = socialMediaUrls.Count;

            var response = socialMediaUrls.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllSocialMediaUrlResponse
            {
                TotalCount = totalCount,
                SocialMediaUrls = response,
            };
        }
    }
}
