using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductModel.Update
{
    public class UpdateProductModelHandler : IRequestHandler<UpdateProductModelRequest, UpdateProductModelResponse>
    {
        readonly IProductModelWriteRepository  _productModelWriteRepository;
        readonly IProductModelReadRepository  _productModelReadRepository;
        readonly IMapper _mapper;

        public UpdateProductModelHandler(IProductModelWriteRepository productModelWriteRepository, IProductModelReadRepository productModelReadRepository, IMapper mapper)
        {
            _productModelWriteRepository = productModelWriteRepository;
            _productModelReadRepository = productModelReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProductModelResponse> Handle(UpdateProductModelRequest request, CancellationToken cancellationToken)
        {
            var productmodel = await _productModelReadRepository.GetByIdAsync(request.Id);
            productmodel = _mapper.Map(request, productmodel);
            await _productModelWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProductModelResponse>(productmodel);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
