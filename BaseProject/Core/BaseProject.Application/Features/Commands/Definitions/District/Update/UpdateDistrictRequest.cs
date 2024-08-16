using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.District.Update
{
    public class UpdateDistrictRequest: IRequest<UpdateDistrictResponse>
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

    }
}