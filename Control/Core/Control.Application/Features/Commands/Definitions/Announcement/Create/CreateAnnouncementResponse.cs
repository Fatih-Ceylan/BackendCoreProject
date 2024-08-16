using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Commands.Definitions.Announcement.Create
{
    public class CreateAnnouncementResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Message { get; set; }
        public List<EmployeeLabelVM> EmployeeLabelsId { get; set; }
        public List<BaseProject.Domain.Entities.GControl.Definitions.DepartmentVM> BaseDepartmentsId { get; set; }
        public bool Success { get; set; }
    }
}
