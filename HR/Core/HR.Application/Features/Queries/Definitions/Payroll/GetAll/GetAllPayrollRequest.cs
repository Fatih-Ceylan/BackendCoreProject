using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace HR.Application.Features.Queries.Definitions.Payroll.GetAll
{
    public class GetAllPayrollRequest : Pagination, IRequest<GetAllPayrollResponse>
    {
    }
}
