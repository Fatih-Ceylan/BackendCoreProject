using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.LoggedInEmployees
{
    public class LoggedInEmployeesRequest : Pagination, IRequest<LoggedInEmployeesResponse>
    {
    }
}
