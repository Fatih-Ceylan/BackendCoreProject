using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Announcement.IsDeletedAnnouncement
{
    public class IsDeletedAnnouncementRequest : Pagination, IRequest<IsDeletedAnnouncementResponse>
    {
        public string? CompanyId { get; set; }
    }
}
