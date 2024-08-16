using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.OpportunitySector.Create
{
    public class CreateOpportunitySectorRequest : IRequest<CreateOpportunitySectorResponse>
    {
        public string Name { get; set; }
    }
}
