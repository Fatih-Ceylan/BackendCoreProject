using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductBrand.Create
{
    public class CreateProductBrandRequest : IRequest<CreateProductBrandResponse>
    {
        public string Name { get; set; }
    }
}
