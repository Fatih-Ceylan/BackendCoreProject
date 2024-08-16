using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Product.GetById
{
    public  class GetByIdProductRequest : IRequest<GetByIdProductResponse>
    {
        public string Id { get; set; }
    }
}
