using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Delete
{
    public class DeleteProductSubCategoryHandler : IRequestHandler<DeleteProductSubCategoryRequest, DeleteProductSubCategoryResponse>
    {
        readonly IProductSubCategoryWriteRepository  _productSubCategoryWriteRepository;

        public DeleteProductSubCategoryHandler(IProductSubCategoryWriteRepository productSubCategoryWriteRepository)
        {
            _productSubCategoryWriteRepository = productSubCategoryWriteRepository;
        }

        public async  Task<DeleteProductSubCategoryResponse> Handle(DeleteProductSubCategoryRequest request, CancellationToken cancellationToken)
        {
            await _productSubCategoryWriteRepository.SoftDeleteAsync(request.Id);
            await _productSubCategoryWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
