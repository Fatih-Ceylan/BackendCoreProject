using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.ToggleEntryExitRecord
{
    public class ToggleEntryExitRecordRequest : IRequest<ToggleEntryExitRecordResponse>
    {
        public string EmployeeId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string LocationId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
