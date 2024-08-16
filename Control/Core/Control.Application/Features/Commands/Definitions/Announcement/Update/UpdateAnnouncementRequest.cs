using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Announcement.Update
{
    public class UpdateAnnouncementRequest : IRequest<UpdateAnnouncementResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string>? EmployeeLabelsId { get; set; }
        public List<string>? BaseDepartmentsId { get; set; }
        public string CompanyId { get; set; }
    }
}
