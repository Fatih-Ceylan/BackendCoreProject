using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Department.TotalDepartmentCount
{
    public class TotalDepartmentCountRequest : Pagination, IRequest<TotalDepartmentCountResponse>
    {
    }
}
