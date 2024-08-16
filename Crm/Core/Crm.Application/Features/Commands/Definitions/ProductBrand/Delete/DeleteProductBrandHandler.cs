using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductBrand.Delete
{
    public class DeleteProductBrandHandler : IRequestHandler<DeleteProductBrandRequest, DeleteProductBrandResponse>
    {
        readonly IProductBrandWriteRepository  _productBrandWriteRepository;

        public DeleteProductBrandHandler(IProductBrandWriteRepository productBrandWriteRepository)
        {
            _productBrandWriteRepository = productBrandWriteRepository;
        }

        public async  Task<DeleteProductBrandResponse> Handle(DeleteProductBrandRequest request, CancellationToken cancellationToken)
        {
            await _productBrandWriteRepository.SoftDeleteAsync(request.Id);
            await _productBrandWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
