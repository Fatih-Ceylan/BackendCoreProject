using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerAddress.Update
{
    public class UpdateCustomerAddressHandler : IRequestHandler<UpdateCustomerAddressRequest, UpdateCustomerAddressResponse>
    {
        readonly ICustomerAddressWriteRepository _customerAddressWriteRepository;
        readonly ICustomerAddressReadRepository _customerAddressReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerAddressHandler(ICustomerAddressWriteRepository customerAddressWriteRepository, ICustomerAddressReadRepository customerAddressReadRepository, IMapper mapper)
        {
            _customerAddressWriteRepository = customerAddressWriteRepository;
            _customerAddressReadRepository = customerAddressReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerAddressResponse> Handle(UpdateCustomerAddressRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerAddressReadRepository.GetByIdAsync(request.Id);
            customer = _mapper.Map(request, customer);
            await _customerAddressWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerAddressResponse>(customer);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}