using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductBrand.Update
{
    public  class UpdateProductBrandRequest :IRequest<UpdateProductBrandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
