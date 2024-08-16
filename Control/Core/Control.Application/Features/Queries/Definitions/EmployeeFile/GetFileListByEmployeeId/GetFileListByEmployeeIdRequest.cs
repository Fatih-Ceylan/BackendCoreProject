using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeFile.GetFileListByEmployeeId
{
    public class GetFileListByEmployeeIdRequest : IRequest<GetFileListByEmployeeIdResponse>
    {
        public string Id { get; set; }
    }
}
