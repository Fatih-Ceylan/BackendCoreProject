using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.Payroll.GetById
{
    public class GetByIdPayrollHandler : IRequestHandler<GetByIdPayrollRequest, GetByIdPayrollResponse>
    {
        public IPayrollReadRepository _payrollReadRepository;

        public GetByIdPayrollHandler(IPayrollReadRepository PayrollReadRepository)
        { _payrollReadRepository = PayrollReadRepository; }

        public async Task<GetByIdPayrollResponse> Handle(GetByIdPayrollRequest request, CancellationToken cancellationToken)
        {
            var payroll = _payrollReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new PayrollVM
                            {
                                Id = c.Id.ToString(),
                                EmployeeId = c.EmployeeId.ToString(),
                                EmployeeName = c.Employee.FirstName,
                                Date = c.Date,
                                DayCount = c.DayCount,
                                SalaryPaid = c.SalaryPaid,
                                SalaryTotal = c.SalaryTotal,
                                CreatedDate = c.CreatedDate
                            }).FirstOrDefault();

            return new() { PayrollVM = payroll };
        }
    }
}
