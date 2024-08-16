using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Airline.Delete
{
    public class DeleteAirlineRequest: IRequest<DeleteAirlineResponse>
    {
        public string Id { get; set; }

    }
}
