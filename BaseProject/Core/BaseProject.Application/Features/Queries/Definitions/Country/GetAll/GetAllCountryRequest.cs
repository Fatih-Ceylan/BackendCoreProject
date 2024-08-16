using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.Country.GetAll
{
    public class GetAllCountryRequest : Pagination, IRequest<GetAllCountryResponse>
    {

    }
}