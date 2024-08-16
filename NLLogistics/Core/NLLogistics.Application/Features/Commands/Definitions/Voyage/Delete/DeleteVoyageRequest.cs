using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Voyage.Delete
{
    public class DeleteVoyageRequest: IRequest<DeleteVoyageResponse>
    {
        public string Id { get; set; }

    }
}
