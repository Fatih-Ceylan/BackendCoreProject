using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.City.Delete
{
    public class DeleteCityRequest: IRequest<DeleteCityResponse>
    {
        public int Id { get; set; }
    }
}