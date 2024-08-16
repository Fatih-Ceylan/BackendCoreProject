using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.MobileGetByIdEntryExitInfo
{
    public class MobileGetByIdEntryExitInfoResponse
    {
        public List<MobileRelatedListByEntryExitIdVM> Data { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }
    }
}
