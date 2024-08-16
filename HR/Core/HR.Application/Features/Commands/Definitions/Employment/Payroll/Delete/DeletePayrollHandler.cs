using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.Payroll.Delete
{
    public class DeletePayrollHandler : IRequestHandler<DeletePayrollRequest, DeletePayrollResponse>
    {
        readonly IPayrollWriteRepository _payrollWriteRepository;

        public DeletePayrollHandler(IPayrollWriteRepository PayrollWriteRepository)
        {
            _payrollWriteRepository = PayrollWriteRepository;
        }

        public async Task<DeletePayrollResponse> Handle(DeletePayrollRequest request, CancellationToken cancellationToken)
        {
            await _payrollWriteRepository.SoftDeleteAsync(request.Id);
            await _payrollWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
