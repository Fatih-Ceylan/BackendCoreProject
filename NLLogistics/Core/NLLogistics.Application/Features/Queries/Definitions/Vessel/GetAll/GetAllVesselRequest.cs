using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace NLLogistics.Application.Features.Queries.Definitions.Vessel.GetAll
{
    public class GetAllVesselRequest: Pagination, IRequest<GetAllVesselResponse>
    {

    }
}