using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.District.Create
{
    public class CreateDistrictRequest: IRequest<CreateDistrictResponse>
    {
        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }
    }
}