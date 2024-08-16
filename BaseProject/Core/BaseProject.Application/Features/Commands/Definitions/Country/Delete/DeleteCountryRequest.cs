using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Country.Delete
{
    public class DeleteCountryRequest: IRequest<DeleteCountryResponse>
    {
        public int Id { get; set; }

    }
}