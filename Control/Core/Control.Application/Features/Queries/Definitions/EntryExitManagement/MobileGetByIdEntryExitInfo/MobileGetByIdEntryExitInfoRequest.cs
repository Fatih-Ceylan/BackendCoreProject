using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.MobileGetByIdEntryExitInfo
{
    public class MobileGetByIdEntryExitInfoRequest : IRequest<MobileGetByIdEntryExitInfoResponse>
    {
        public string Id { get; set; }
        public string BranchId { get; set; }
        public string CompanyId { get; set; }
        public string Token { get; set; }
        public string? FilterPeriod { get; set; }
    }
}
