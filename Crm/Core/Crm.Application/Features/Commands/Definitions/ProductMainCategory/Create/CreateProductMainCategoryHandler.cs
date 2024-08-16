using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Create
{
    public class CreateProductMainCategoryHandler : IRequestHandler<CreateProductMainCategoryRequest, CreateProductMainCategoryResponse>
    {
        readonly IProductMainCategoryWriteRepository  _productMainCategoryWriteRepository;
        readonly IMapper _mapper;

        public CreateProductMainCategoryHandler(IProductMainCategoryWriteRepository productMainCategoryWriteRepository, IMapper mapper)
        {
            _productMainCategoryWriteRepository = productMainCategoryWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProductMainCategoryResponse> Handle(CreateProductMainCategoryRequest request, CancellationToken cancellationToken)
        {
            var productmaincategory = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products.ProductMainCategory>(request);
            productmaincategory = await _productMainCategoryWriteRepository.AddAsync(productmaincategory);
            await _productMainCategoryWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductMainCategoryResponse>(productmaincategory);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
