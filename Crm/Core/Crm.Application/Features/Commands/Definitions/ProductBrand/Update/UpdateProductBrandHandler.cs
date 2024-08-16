using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProductBrand.Update
{
    public class UpdateProductBrandHandler : IRequestHandler<UpdateProductBrandRequest, UpdateProductBrandResponse>
    {
        readonly IProductBrandWriteRepository  _productBrandWriteRepository;
        readonly IProductBrandReadRepository  _productBrandReadRepository;
        readonly IMapper _mapper;

        public UpdateProductBrandHandler(IProductBrandWriteRepository productBrandWriteRepository, IProductBrandReadRepository productBrandReadRepository, IMapper mapper)
        {
            _productBrandWriteRepository = productBrandWriteRepository;
            _productBrandReadRepository = productBrandReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProductBrandResponse> Handle(UpdateProductBrandRequest request, CancellationToken cancellationToken)
        {
            var productbrand = await _productBrandReadRepository.GetByIdAsync(request.Id);
            productbrand = _mapper.Map(request, productbrand);
            await _productBrandWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProductBrandResponse>(productbrand);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
