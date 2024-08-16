using MediatR;

namespace HR.Application.Features.Queries.Definitions.Payroll.GetById
{
    public class GetByIdPayrollRequest : IRequest<GetByIdPayrollResponse>
    {
        public string Id { get; set; }
    }
}
