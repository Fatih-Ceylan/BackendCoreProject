using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.City.Update
{
    public class UpdateCityRequest: IRequest<UpdateCityResponse>
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; }
    }
}