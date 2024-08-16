using MediatR;

namespace GControl.Application.Features.Commands.Definitions.AnnouncmentIsDeletedStatus
{
    public class AnnouncementIsDeletedStatusRequest : IRequest<AnnouncementIsDeletedStatusResponse>
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
