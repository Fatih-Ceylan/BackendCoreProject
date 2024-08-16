using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.Product.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        readonly IProductWriteRepository  _productWriteRepository;
        readonly IMapper _mapper;

        public CreateProductHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products.Product>(request);
            product = await _productWriteRepository.AddAsync(product);
            await _productWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductResponse>(product);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
