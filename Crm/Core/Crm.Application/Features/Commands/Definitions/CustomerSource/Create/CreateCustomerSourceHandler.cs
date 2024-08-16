using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSource.Create
{
    public class CreateCustomerSourceHandler : IRequestHandler<CreateCustomerSourceRequest, CreateCustomerSourceResponse>
    {
        readonly ICustomerSourceWriteRepository _customerSourceWriteRepository;
        readonly IMapper _mapper;
        public CreateCustomerSourceHandler(ICustomerSourceWriteRepository customerSourceWriteRepository, IMapper mapper)
        {
            _customerSourceWriteRepository = customerSourceWriteRepository;
            _mapper = mapper;
        }
        public async Task<CreateCustomerSourceResponse> Handle(CreateCustomerSourceRequest request, CancellationToken cancellationToken)
        {
            var customerSource = _mapper.Map<T.CustomerManagement.Customers.CustomerSource>(request);

            customerSource = await _customerSourceWriteRepository.AddAsync(customerSource);
            await _customerSourceWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerSourceResponse>(customerSource);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
