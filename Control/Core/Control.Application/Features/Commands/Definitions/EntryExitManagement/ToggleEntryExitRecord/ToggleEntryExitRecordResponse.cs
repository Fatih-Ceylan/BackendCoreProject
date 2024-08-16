namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.ToggleEntryExitRecord
{
    public class ToggleEntryExitRecordResponse
    {
        public string EmployeeId { get; set; }
        public bool IsRegistrationType { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string LocationId { get; set; }
        public string Message { get; set; }
    }
}
