using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace HR.Application.Features.Queries.Definitions.Employee.GetAll
{
    public class GetAllEmployeeRequest : Pagination, IRequest<GetAllEmployeeResponse>
    {
    }
}
