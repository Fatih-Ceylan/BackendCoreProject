using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Airport.Delete
{
    public class DeleteAirportRequest: IRequest<DeleteAirportResponse>
    {
        public string Id { get; set; }

    }
}
