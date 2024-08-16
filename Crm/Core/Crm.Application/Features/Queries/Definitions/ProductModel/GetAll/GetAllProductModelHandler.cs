using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductModel.GetAll
{
    public class GetAllProductModelHandler : IRequestHandler<GetAllProductModelRequest, GetAllProductModelResponse>
    {
        readonly IProductModelReadRepository  _productModelReadRepository;

        public GetAllProductModelHandler(IProductModelReadRepository productModelReadRepository)
        {
            _productModelReadRepository = productModelReadRepository;
        }

        public Task<GetAllProductModelResponse> Handle(GetAllProductModelRequest request, CancellationToken cancellationToken)
        {
            var query = _productModelReadRepository.GetAllDeletedStatusDesc(false)
         .Select(or => new ProductModelVM
         {
             Id = or.Id.ToString(),
             ProductModelName = or.ProductModelName,


         });

            var totalCount = query.Count();
            var productModels  = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProductModelResponse
            {
                TotalCount = totalCount,
                productModels = productModels,
            });
        }
    }
}
