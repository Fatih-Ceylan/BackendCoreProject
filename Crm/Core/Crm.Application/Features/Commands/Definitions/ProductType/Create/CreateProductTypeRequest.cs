using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductType.Create
{
    public  class CreateProductTypeRequest :IRequest<CreateProductTypeResponse>
    {
        public string Name { get; set; }
    }
}
