using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunitySector.Update
{
    public  class UpdateOpportunitySectorRequest : IRequest<UpdateOpportunitySectorResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
