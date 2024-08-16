using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductType.Create
{
    public class CreateProductTypeHandler : IRequestHandler<CreateProductTypeRequest, CreateProductTypeResponse>
    {
        readonly IProductTypeWriteRepository  _productTypeWriteRepository;
        readonly IMapper _mapper;

        public CreateProductTypeHandler(IProductTypeWriteRepository productTypeWriteRepository, IMapper mapper)
        {
            _productTypeWriteRepository = productTypeWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProductTypeResponse> Handle(CreateProductTypeRequest request, CancellationToken cancellationToken)
        {
            var producttype = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products.ProductType>(request);
            producttype = await _productTypeWriteRepository.AddAsync(producttype);
            await _productTypeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductTypeResponse>(producttype);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
