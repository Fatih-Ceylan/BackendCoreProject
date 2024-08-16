using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.OpportunitySector.GetById
{
    public  class GetByIdOpportunitySectorRequest : IRequest<GetByIdOpportunitySectorResponse>
    {
        public string  Id { get; set; }
    }
}
