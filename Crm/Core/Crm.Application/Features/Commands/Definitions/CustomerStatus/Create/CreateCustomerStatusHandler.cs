using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;


namespace GCrm.Application.Features.Commands.Definitions.CustomerStatus.Create
{
    public class CreateCustomerStatusHandler : IRequestHandler<CreateCustomerStatusRequest, CreateCustomerStatusResponse>
    {

        readonly ICustomerStatusWriteRepository _customerStatusWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerStatusHandler(ICustomerStatusWriteRepository customerStatusWriteRepository, IMapper mapper)
        {
            _customerStatusWriteRepository = customerStatusWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerStatusResponse> Handle(CreateCustomerStatusRequest request, CancellationToken cancellationToken)
        {
            var customerStatus = _mapper.Map<T.CustomerStatus>(request);

            customerStatus = await _customerStatusWriteRepository.AddAsync(customerStatus);
            await _customerStatusWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerStatusResponse>(customerStatus);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
