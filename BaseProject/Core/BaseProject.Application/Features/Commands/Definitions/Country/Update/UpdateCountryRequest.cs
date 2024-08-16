using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Country.Update
{
    public class UpdateCountryRequest: IRequest<UpdateCountryResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}