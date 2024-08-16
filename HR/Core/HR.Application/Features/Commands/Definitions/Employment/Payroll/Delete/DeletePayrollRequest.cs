using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Payroll.Delete
{
    public class DeletePayrollRequest : IRequest<DeletePayrollResponse>
    {
        public string Id { get; set; }
    }
}
