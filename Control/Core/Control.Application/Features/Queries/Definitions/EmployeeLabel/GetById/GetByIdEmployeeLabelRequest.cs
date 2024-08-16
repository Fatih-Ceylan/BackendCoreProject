using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetById
{
    public class GetByIdEmployeeLabelRequest : IRequest<GetByIdEmployeeLabelResponse>
    {
        public string Id { get; set; }
    }
}
