using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductCategory.Update
{
    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryRequest, UpdateProductCategoryResponse>
    {
        readonly IProductCategoryWriteRepository  _productCategoryWriteRepository;
        readonly IProductCategoryReadRepository  _productCategoryReadRepository;
        readonly IMapper _mapper;

        public UpdateProductCategoryHandler(IProductCategoryWriteRepository productCategoryWriteRepository, IProductCategoryReadRepository productCategoryReadRepository, IMapper mapper)
        {
            _productCategoryWriteRepository = productCategoryWriteRepository;
            _productCategoryReadRepository = productCategoryReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProductCategoryResponse> Handle(UpdateProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var productcategory = await _productCategoryReadRepository.GetByIdAsync(request.Id);
            productcategory = _mapper.Map(request, productcategory);
            await _productCategoryWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProductCategoryResponse>(productcategory);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
