using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.District.GetAll
{
    public class GetAllDistrictRequest: Pagination, IRequest<GetAllDistrictResponse>
    {
        public int? CityId { get; set; }
    }
}