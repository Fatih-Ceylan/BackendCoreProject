using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductBrand.Create
{
    public class CreateProductBrandHandler : IRequestHandler<CreateProductBrandRequest, CreateProductBrandResponse>
    {
        readonly IProductBrandWriteRepository  _productBrandWriteRepository;
        readonly IMapper _mapper;

        public CreateProductBrandHandler(IProductBrandWriteRepository productBrandWriteRepository, IMapper mapper)
        {
            _productBrandWriteRepository = productBrandWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProductBrandResponse> Handle(CreateProductBrandRequest request, CancellationToken cancellationToken)
        {
            var productbrand = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products.ProductBrand>(request);
            productbrand = await _productBrandWriteRepository.AddAsync(productbrand);
            await _productBrandWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductBrandResponse>(productbrand);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
