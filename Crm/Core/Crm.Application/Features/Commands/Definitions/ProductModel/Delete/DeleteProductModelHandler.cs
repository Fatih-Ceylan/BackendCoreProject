using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductModel.Delete
{
    public class DeleteProductModelHandler : IRequestHandler<DeleteProductModelRequest, DeleteProductModelResponse>
    {
        readonly IProductModelWriteRepository  _productModelWriteRepository;

        public DeleteProductModelHandler(IProductModelWriteRepository productModelWriteRepository)
        {
            _productModelWriteRepository = productModelWriteRepository;
        }

        public async  Task<DeleteProductModelResponse> Handle(DeleteProductModelRequest request, CancellationToken cancellationToken)
        {
            await _productModelWriteRepository.SoftDeleteAsync(request.Id);
            await _productModelWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
