using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.EmployeeEntryInAndOut
{
    public class EmployeeEntryInAndOutRequest : Pagination, IRequest<EmployeeEntryInAndOutResponse>
    {
    }
}
