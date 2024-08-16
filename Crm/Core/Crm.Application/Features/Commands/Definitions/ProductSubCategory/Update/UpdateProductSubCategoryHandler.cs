using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Update
{
    public class UpdateProductSubCategoryHandler : IRequestHandler<UpdateProductSubCategoryRequest, UpdateProductSubCategoryResponse>
    {
        readonly IProductSubCategoryWriteRepository  _productSubCategoryWriteRepository;
        readonly IProductSubCategoryReadRepository  _productSubCategoryReadRepository;
        readonly IMapper _mapper;

        public UpdateProductSubCategoryHandler(IProductSubCategoryWriteRepository productSubCategoryWriteRepository, IProductSubCategoryReadRepository productSubCategoryReadRepository, IMapper mapper)
        {
            _productSubCategoryWriteRepository = productSubCategoryWriteRepository;
            _productSubCategoryReadRepository = productSubCategoryReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProductSubCategoryResponse> Handle(UpdateProductSubCategoryRequest request, CancellationToken cancellationToken)
        {
            var productsubcategory = await _productSubCategoryReadRepository.GetByIdAsync(request.Id);
            productsubcategory = _mapper.Map(request, productsubcategory);
            await _productSubCategoryWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProductSubCategoryResponse>(productsubcategory);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
