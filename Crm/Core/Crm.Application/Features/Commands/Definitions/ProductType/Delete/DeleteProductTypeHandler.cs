using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductType.Delete
{
    public class DeleteProductTypeHandler : IRequestHandler<DeleteProductTypeRequest, DeleteProductTypeResponse>
    {
        readonly IProductTypeWriteRepository  _productTypeWriteRepository;

        public DeleteProductTypeHandler(IProductTypeWriteRepository productTypeWriteRepository)
        {
            _productTypeWriteRepository = productTypeWriteRepository;
        }

        public async  Task<DeleteProductTypeResponse> Handle(DeleteProductTypeRequest request, CancellationToken cancellationToken)
        {
            await _productTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _productTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
