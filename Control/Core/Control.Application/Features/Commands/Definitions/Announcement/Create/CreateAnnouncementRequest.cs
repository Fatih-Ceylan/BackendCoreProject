using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Announcement.Create
{
    public class CreateAnnouncementRequest : IRequest<CreateAnnouncementResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string>? EmployeeLabelsId { get; set; }
        public List<string>? BaseDepartmentsId { get; set; }
        public string? CompanyId { get; set; }
        public string? Message { get; set; }
    }
}
