using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductType.GetById
{
    public  class GetByIdProductTypeRequest :IRequest<GetByIdProductTypeResponse>
    {
        public string Id { get; set; }
    }
}
