using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductBrand.GetById
{
    public  class GetByIdProductBrandRequest :IRequest<GetByIdProductBrandResponse>
    {
        public string Id { get; set; }
    }
}
