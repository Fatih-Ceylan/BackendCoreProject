using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Country.Create
{
    public class CreateCountryRequest: IRequest<CreateCountryResponse>
    {
        public string Name { get; set; }
    }
}