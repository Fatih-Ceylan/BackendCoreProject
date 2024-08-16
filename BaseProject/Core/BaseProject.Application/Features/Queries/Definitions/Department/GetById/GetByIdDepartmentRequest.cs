using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetById
{
    public class GetByIdDepartmentRequest : IRequest<GetByIdDepartmentResponse>
    {
        public string Id { get; set; }
    }
}