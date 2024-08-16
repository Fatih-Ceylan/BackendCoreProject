using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;


namespace GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Create
{
    public class CreateProductSubCategoryHandler : IRequestHandler<CreateProductSubCategoryRequest, CreateProductSubCategoryResponse>
    {
        readonly IProductSubCategoryWriteRepository  _productSubCategoryWriteRepository;
        readonly IMapper _mapper;

        public CreateProductSubCategoryHandler(IProductSubCategoryWriteRepository productSubCategoryWriteRepository, IMapper mapper)
        {
            _productSubCategoryWriteRepository = productSubCategoryWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProductSubCategoryResponse> Handle(CreateProductSubCategoryRequest request, CancellationToken cancellationToken)
        {
            var productsubcategory = _mapper.Map<T.ProductSubCategory>(request);
            productsubcategory = await _productSubCategoryWriteRepository.AddAsync(productsubcategory);
            await _productSubCategoryWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductSubCategoryResponse>(productsubcategory);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
