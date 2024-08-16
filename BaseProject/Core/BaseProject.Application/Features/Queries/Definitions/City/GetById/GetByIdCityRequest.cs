using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.City.GetById
{
    public class GetByIdCityRequest: IRequest<GetByIdCityResponse>
    {
        public int Id { get; set; }
    }
}