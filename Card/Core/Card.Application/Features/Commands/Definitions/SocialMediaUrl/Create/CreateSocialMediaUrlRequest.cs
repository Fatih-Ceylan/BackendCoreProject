using MediatR;

namespace Card.Application.Features.Commands.Definitions.SocialMediaUrl.Create
{
    public class CreateSocialMediaUrlRequest : IRequest<CreateSocialMediaUrlResponse>
    {
        public string SocialMediaId { get; set; }
        public string StaffId { get; set; }
        public string UrlPath { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }

    }
}
