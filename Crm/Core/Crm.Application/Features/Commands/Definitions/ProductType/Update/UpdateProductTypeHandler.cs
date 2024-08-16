using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductType.Update
{
    public class UpdateProductTypeHandler : IRequestHandler<UpdateProductTypeRequest, UpdateProductTypeResponse>
    {
        readonly IProductTypeWriteRepository  _productTypeWriteRepository;
        readonly IProductTypeReadRepository  _productTypeReadRepository;
        readonly IMapper _mapper;

        public UpdateProductTypeHandler(IProductTypeWriteRepository productTypeWriteRepository, IProductTypeReadRepository productTypeReadRepository, IMapper mapper)
        {
            _productTypeWriteRepository = productTypeWriteRepository;
            _productTypeReadRepository = productTypeReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProductTypeResponse> Handle(UpdateProductTypeRequest request, CancellationToken cancellationToken)
        {
            var producttype = await _productTypeReadRepository.GetByIdAsync(request.Id);
            producttype = _mapper.Map(request, producttype);
            await _productTypeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProductTypeResponse>(producttype);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
