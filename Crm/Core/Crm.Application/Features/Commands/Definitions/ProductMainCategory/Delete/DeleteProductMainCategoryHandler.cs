using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Delete
{
    public class DeleteProductMainCategoryHandler : IRequestHandler<DeleteProductMainCategoryRequest, DeleteProductMainCategoryResponse>
    {
        readonly IProductMainCategoryWriteRepository  _productMainCategoryWriteRepository;

        public DeleteProductMainCategoryHandler(IProductMainCategoryWriteRepository productMainCategoryWriteRepository)
        {
            _productMainCategoryWriteRepository = productMainCategoryWriteRepository;
        }

        public async Task<DeleteProductMainCategoryResponse> Handle(DeleteProductMainCategoryRequest request, CancellationToken cancellationToken)
        {
            await _productMainCategoryWriteRepository.SoftDeleteAsync(request.Id);
            await _productMainCategoryWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
