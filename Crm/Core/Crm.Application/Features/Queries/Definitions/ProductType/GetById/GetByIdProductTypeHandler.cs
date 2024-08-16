using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProductType.GetById
{
    public class GetByIdProductTypeHandler : IRequestHandler<GetByIdProductTypeRequest, GetByIdProductTypeResponse>
    {
        readonly IProductTypeReadRepository  _productTypeReadRepository;

        public GetByIdProductTypeHandler(IProductTypeReadRepository productTypeReadRepository)
        {
            _productTypeReadRepository = productTypeReadRepository;
        }

        public async  Task<GetByIdProductTypeResponse> Handle(GetByIdProductTypeRequest request, CancellationToken cancellationToken)
        {
            var producttype = _productTypeReadRepository
                    .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                    .Select(ct => new ProductTypeVM
                    {
                        Id = ct.Id.ToString(),
                        Name = ct.Name

                    }).FirstOrDefault();

            return new()
            {
                productType = producttype
            };
        }
    }
}
