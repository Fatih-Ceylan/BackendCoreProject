using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Announcement.Delete
{
    public class DeleteAnnouncementRequest : IRequest<DeleteAnnouncementResponse>
    {
        public string Id { get; set; }
    }
}
