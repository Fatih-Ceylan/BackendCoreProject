using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductModel.GetById
{
    public class GetByIdProductModelHandler : IRequestHandler<GetByIdProductModelRequest, GetByIdProductModelResponse>
    {
        readonly IProductModelReadRepository  _productModelReadRepository;

        public GetByIdProductModelHandler(IProductModelReadRepository productModelReadRepository)
        {
            _productModelReadRepository = productModelReadRepository;
        }

        public async  Task<GetByIdProductModelResponse> Handle(GetByIdProductModelRequest request, CancellationToken cancellationToken)
        {
            var productModel = _productModelReadRepository
                     .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                     .Select(ct => new ProductModelVM
                     {
                         Id = ct.Id.ToString(),
                         ProductModelName = ct.ProductModelName

                     }).FirstOrDefault();

            return new()
            {
                productModel = productModel
            };
        }
    }
}
