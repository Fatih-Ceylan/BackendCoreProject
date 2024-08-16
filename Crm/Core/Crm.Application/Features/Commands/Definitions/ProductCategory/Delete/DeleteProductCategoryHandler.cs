using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductCategory.Delete
{
    public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryRequest, DeleteProductCategoryResponse>
    {
        readonly IProductCategoryWriteRepository  _productCategoryWriteRepository;

        public DeleteProductCategoryHandler(IProductCategoryWriteRepository productCategoryWriteRepository)
        {
            _productCategoryWriteRepository = productCategoryWriteRepository;
        }

        public async  Task<DeleteProductCategoryResponse> Handle(DeleteProductCategoryRequest request, CancellationToken cancellationToken)
        {
            await _productCategoryWriteRepository.SoftDeleteAsync(request.Id);
            await _productCategoryWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
