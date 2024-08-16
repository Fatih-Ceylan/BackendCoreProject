using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Announcement.GetAll
{
    public class GetAllAnnouncementResponse
    {
        public int TotalCount { get; set; }
        public List<AnnouncementVM> Announcements { get; set; }
    }
}
