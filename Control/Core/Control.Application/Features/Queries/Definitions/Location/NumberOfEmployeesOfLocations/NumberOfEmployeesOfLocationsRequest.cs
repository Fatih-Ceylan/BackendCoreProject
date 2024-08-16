using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Location.NumberOfEmployeesOfLocations
{
    public class NumberOfEmployeesOfLocationsRequest : Pagination, IRequest<NumberOfEmployeesOfLocationsResponse>
    {
    }
}
