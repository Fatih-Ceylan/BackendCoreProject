using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Announcement.GetById
{
    public class GetByIdAnnouncementRequest : IRequest<GetByIdAnnouncementResponse>
    {
        public string Id { get; set; }
    }
}
