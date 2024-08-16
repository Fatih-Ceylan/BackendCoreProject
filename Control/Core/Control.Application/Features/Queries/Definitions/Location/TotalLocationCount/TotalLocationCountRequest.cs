using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Location.TotalLocationCount
{
    public class TotalLocationCountRequest : Pagination, IRequest<TotalLocationCountResponse>
    {
    }
}
