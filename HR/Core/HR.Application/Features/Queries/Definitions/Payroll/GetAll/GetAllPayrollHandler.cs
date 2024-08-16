using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.Payroll.GetAll
{
    public class GetAllPayrollHandler : IRequestHandler<GetAllPayrollRequest, GetAllPayrollResponse>
    {
        public IPayrollReadRepository _payrollReadRepository;

        public GetAllPayrollHandler(IPayrollReadRepository PayrollReadRepository)
        {
            _payrollReadRepository = PayrollReadRepository;
        }

        public Task<GetAllPayrollResponse> Handle(GetAllPayrollRequest request, CancellationToken cancellationToken)
        {
            var query = _payrollReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
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
               });
            var totalCount = query.Count();
            var Payrolls = request.DoPagination ? query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList() : query.ToList();

            return Task.FromResult(new GetAllPayrollResponse
            {
                TotalCount = totalCount,
                PayrollVMs = Payrolls,
            });
        }
    }
}
