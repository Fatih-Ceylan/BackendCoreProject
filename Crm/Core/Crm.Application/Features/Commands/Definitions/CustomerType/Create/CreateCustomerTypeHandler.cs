using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;


namespace GCrm.Application.Features.Commands.Definitions.CustomerType.Create
{
    public class CreateCustomerTypeHandler : IRequestHandler<CreateCustomerTypeRequest, CreateCustomerTypeResponse>
    {
        readonly ICustomerTypeWriteRepository _customerTypeWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerTypeHandler(ICustomerTypeWriteRepository companyWriteRepository, IMapper mapper)
        {
            _customerTypeWriteRepository = companyWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerTypeResponse> Handle(CreateCustomerTypeRequest request, CancellationToken cancellationToken)
        {
            T.CustomerType customerType = _mapper.Map<T.CustomerType>(request);

            customerType = await _customerTypeWriteRepository.AddAsync(customerType);
            await _customerTypeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerTypeResponse>(customerType);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}