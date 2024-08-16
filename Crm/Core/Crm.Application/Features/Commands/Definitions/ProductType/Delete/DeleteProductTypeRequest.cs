using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductType.Delete
{
    public  class DeleteProductTypeRequest :IRequest<DeleteProductTypeResponse>
    {
        public string Id { get; set; }
    }
}
