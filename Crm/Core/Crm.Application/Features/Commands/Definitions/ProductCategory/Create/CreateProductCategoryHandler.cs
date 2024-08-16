using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductCategory.Create
{
    public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryRequest, CreateProductCategoryResponse>
    {

        readonly IProductCategoryWriteRepository  _productCategoryWriteRepository;
        readonly IMapper _mapper;

        public CreateProductCategoryHandler(IProductCategoryWriteRepository productCategoryWriteRepository, IMapper mapper)
        {
            _productCategoryWriteRepository = productCategoryWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProductCategoryResponse> Handle(CreateProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var productcategory = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products.ProductCategory>(request);
            productcategory = await _productCategoryWriteRepository.AddAsync(productcategory);
            await _productCategoryWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductCategoryResponse>(productcategory);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
