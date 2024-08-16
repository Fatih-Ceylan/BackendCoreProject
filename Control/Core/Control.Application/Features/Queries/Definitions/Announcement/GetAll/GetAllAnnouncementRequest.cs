using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Announcement.GetAll
{
    public class GetAllAnnouncementRequest : Pagination, IRequest<GetAllAnnouncementResponse>
    {
        public string? CompanyId { get; set; }
        public string? FilterPeriod { get; set; }
    }
}
