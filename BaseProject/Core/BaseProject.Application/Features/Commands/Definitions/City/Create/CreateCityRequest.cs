using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.City.Create
{
    public class CreateCityRequest: IRequest<CreateCityResponse>
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

    }
}