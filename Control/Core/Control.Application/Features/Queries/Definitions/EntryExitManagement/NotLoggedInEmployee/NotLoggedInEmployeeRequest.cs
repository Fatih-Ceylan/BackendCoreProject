using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.NotLoggedInEmployee
{
    public class NotLoggedInEmployeeRequest : Pagination, IRequest<NotLoggedInEmployeeResponse>
    {
    }
}
