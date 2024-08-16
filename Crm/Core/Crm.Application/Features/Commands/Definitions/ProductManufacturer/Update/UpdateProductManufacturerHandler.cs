using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Update
{
    public class UpdateProductManufacturerHandler : IRequestHandler<UpdateProductManufacturerRequest, UpdateProductManufacturerResponse>
    {
        readonly IProductManufacturerWriteRepository  _productManufacturerWriteRepository;
        readonly IProductManufacturerReadRepository  _productManufacturerReadRepository;
        readonly IMapper _mapper;

        public UpdateProductManufacturerHandler(IProductManufacturerWriteRepository productManufacturerWriteRepository, IProductManufacturerReadRepository productManufacturerReadRepository, IMapper mapper)
        {
            _productManufacturerWriteRepository = productManufacturerWriteRepository;
            _productManufacturerReadRepository = productManufacturerReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProductManufacturerResponse> Handle(UpdateProductManufacturerRequest request, CancellationToken cancellationToken)
        {
            var productmanufacturer = await _productManufacturerReadRepository.GetByIdAsync(request.Id);
            productmanufacturer = _mapper.Map(request, productmanufacturer);
            await _productManufacturerWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProductManufacturerResponse>(productmanufacturer);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
