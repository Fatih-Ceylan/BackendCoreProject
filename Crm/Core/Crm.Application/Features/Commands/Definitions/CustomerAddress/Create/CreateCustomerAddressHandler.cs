using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerAddress.Create
{
    public class CreateCustomerAddressHandler : IRequestHandler<CreateCustomerAddressRequest, CreateCustomerAddressResponse>
    {
        readonly ICustomerAddressWriteRepository _customerAddressWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerAddressHandler(ICustomerAddressWriteRepository customerAddressWriteRepository, IMapper mapper)
        {
            _customerAddressWriteRepository = customerAddressWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerAddressResponse> Handle(CreateCustomerAddressRequest request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers.CustomerAddress>(request);

            customer = await _customerAddressWriteRepository.AddAsync(customer);
            await _customerAddressWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerAddressResponse>(customer);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}