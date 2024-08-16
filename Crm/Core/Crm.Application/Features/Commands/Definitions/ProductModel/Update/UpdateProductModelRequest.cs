using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductModel.Update
{
    public  class UpdateProductModelRequest :IRequest<UpdateProductModelResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
