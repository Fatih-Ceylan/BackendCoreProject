using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeType.GetById
{
    public class GetByIdEmployeeTypeRequest : IRequest<GetByIdEmployeeTypeResponse>
    {
        public string Id { get; set; }
    }
}
