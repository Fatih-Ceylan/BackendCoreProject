using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Delete
{
    public class DeleteProductManufacturerHandler : IRequestHandler<DeleteProductManufacturerRequest, DeleteProductManufacturerResponse>
    {
        readonly IProductManufacturerWriteRepository  _productManufacturerWriteRepository;

        public DeleteProductManufacturerHandler(IProductManufacturerWriteRepository productManufacturerWriteRepository)
        {
            _productManufacturerWriteRepository = productManufacturerWriteRepository;
        }

        public async  Task<DeleteProductManufacturerResponse> Handle(DeleteProductManufacturerRequest request, CancellationToken cancellationToken)
        {
            await _productManufacturerWriteRepository.SoftDeleteAsync(request.Id);
            await _productManufacturerWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
