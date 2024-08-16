using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductModel.Create
{
    public  class CreateProductModelRequest :IRequest<CreateProductModelResponse>
    {
        public string Name { get; set; }
    }
}
