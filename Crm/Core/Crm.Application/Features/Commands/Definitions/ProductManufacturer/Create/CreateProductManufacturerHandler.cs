using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Create
{
    public class CreateProductManufacturerHandler : IRequestHandler<CreateProductManufacturerRequest, CreateProductManufacturerResponse>
    {
        readonly IProductManufacturerWriteRepository  _productManufacturerWriteRepository;
        readonly IMapper _mapper;

        public CreateProductManufacturerHandler(IProductManufacturerWriteRepository productManufacturerWriteRepository, IMapper mapper)
        {
            _productManufacturerWriteRepository = productManufacturerWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductManufacturerResponse> Handle(CreateProductManufacturerRequest request, CancellationToken cancellationToken)
        {
            var productmanufacturer = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products.ProductManufacturer>(request);
            productmanufacturer = await _productManufacturerWriteRepository.AddAsync(productmanufacturer);
            await _productManufacturerWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductManufacturerResponse>(productmanufacturer);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
