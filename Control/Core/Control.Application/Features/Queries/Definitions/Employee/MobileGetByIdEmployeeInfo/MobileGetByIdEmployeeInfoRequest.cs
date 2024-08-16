using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Employee.MobileGetByIdEmployeeInfo
{
    public class MobileGetByIdEmployeeInfoRequest : IRequest<MobileGetByIdEmployeeInfoResponse>
    {
        public string Id { get; set; }
        public string Token { get; set; }
    }
}
