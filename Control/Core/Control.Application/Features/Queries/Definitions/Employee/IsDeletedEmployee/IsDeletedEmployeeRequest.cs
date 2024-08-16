using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Employee.BringAllEmployee
{
    public class IsDeletedEmployeeRequest : Pagination, IRequest<IsDeletedEmployeeResponse>
    {
        public string? CompanyId { get; set; }
    }
}
