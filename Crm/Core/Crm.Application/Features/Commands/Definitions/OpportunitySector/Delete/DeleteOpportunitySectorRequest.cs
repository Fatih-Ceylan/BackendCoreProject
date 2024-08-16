using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunitySector.Delete
{
    public  class DeleteOpportunitySectorRequest : IRequest<DeleteOpportunitySectorResponse>
    {
        public string Id { get; set; }
    }
}
