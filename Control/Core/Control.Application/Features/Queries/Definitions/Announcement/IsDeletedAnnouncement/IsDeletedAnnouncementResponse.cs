using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Announcement.IsDeletedAnnouncement
{
    public class IsDeletedAnnouncementResponse
    {
        public int TotalCount { get; set; }
        public List<AnnouncementVM> Announcements { get; set; }
    }
}
