using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductBrand.Delete
{
    public  class DeleteProductBrandRequest :IRequest<DeleteProductBrandResponse>
    {
        public string Id { get; set; }
    }
}
