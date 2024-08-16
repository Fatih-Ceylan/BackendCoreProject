using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Employee.MobileGetByIdEmployeeInfo
{
    public class MobileGetByIdEmployeeInfoResponse
    {
        public MobileRelatedListByEmployeeIdVM Data { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }
    }
}
