using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.ProductType.Update
{
    public class UpdateProductTypeRequest:IRequest<UpdateProductTypeResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
