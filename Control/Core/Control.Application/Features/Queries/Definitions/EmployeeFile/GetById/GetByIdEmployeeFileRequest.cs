using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeFile.GetById
{
    public class GetByIdEmployeeFileRequest : IRequest<GetByIdEmployeeFileResponse>
    {
        public string Id { get; set; }
    }
}
