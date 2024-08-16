using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;


namespace GCrm.Application.Features.Commands.Definitions.ProductModel.Create
{
    public class CreateProductModelHandler : IRequestHandler<CreateProductModelRequest, CreateProductModelResponse>
    {
        readonly IProductModelWriteRepository  _productModelWriteRepository;
        readonly IMapper _mapper;

        public CreateProductModelHandler(IProductModelWriteRepository productModelWriteRepository, IMapper mapper)
        {
            _productModelWriteRepository = productModelWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProductModelResponse> Handle(CreateProductModelRequest request, CancellationToken cancellationToken)
        {
            var productmodel = _mapper.Map<T.ProductModel>(request);
            productmodel = await _productModelWriteRepository.AddAsync(productmodel);
            await _productModelWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProductModelResponse>(productmodel);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
