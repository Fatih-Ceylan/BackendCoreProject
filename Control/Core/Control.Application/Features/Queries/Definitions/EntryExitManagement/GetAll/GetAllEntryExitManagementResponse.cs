using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.GetAll
{
    public class GetAllEntryExitManagementResponse
    {
        public int TotalCount { get; set; }

        public List<EntryExitManagementVM> EntryExitManagements { get; set; }
    }
}
