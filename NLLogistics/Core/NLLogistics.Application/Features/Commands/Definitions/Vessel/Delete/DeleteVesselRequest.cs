using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Vessel.Delete
{
    public class DeleteVesselRequest: IRequest<DeleteVesselResponse>
    {
        public string Id { get; set; }

    }
}
