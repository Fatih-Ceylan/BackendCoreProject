using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductModel.GetById
{
    public class GetByIdProductModelRequest :IRequest<GetByIdProductModelResponse>
    {
        public string Id { get; set; }
    }
}
