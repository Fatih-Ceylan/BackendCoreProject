using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Update
{
    public class UpdateProductMainCategoryHandler : IRequestHandler<UpdateProductMainCategoryRequest, UpdateProductMainCategoryResponse>
    {
        readonly IProductMainCategoryWriteRepository  _productMainCategoryWriteRepository;
        readonly IProductMainCategoryReadRepository  _productMainCategoryReadRepository;
        readonly IMapper _mapper;

        public UpdateProductMainCategoryHandler(IProductMainCategoryWriteRepository productMainCategoryWriteRepository, IProductMainCategoryReadRepository productMainCategoryReadRepository, IMapper mapper)
        {
            _productMainCategoryWriteRepository = productMainCategoryWriteRepository;
            _productMainCategoryReadRepository = productMainCategoryReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProductMainCategoryResponse> Handle(UpdateProductMainCategoryRequest request, CancellationToken cancellationToken)
        {
            var productmaincategory = await _productMainCategoryReadRepository.GetByIdAsync(request.Id);
            productmaincategory = _mapper.Map(request, productmaincategory);
            await _productMainCategoryWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProductMainCategoryResponse>(productmaincategory);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
