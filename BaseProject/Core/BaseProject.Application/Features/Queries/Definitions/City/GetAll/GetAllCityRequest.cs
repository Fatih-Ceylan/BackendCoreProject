using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.City.GetAll
{
    public class GetAllCityRequest: Pagination, IRequest<GetAllCityResponse>
    {
        public int? CountryId { get; set; }

    }
}