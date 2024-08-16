using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;


namespace GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Create
{
    public class CreateCustomerRepresentativeHandler : IRequestHandler<CreateCustomerRepresentativeRequest, CreateCustomerRepresentativeResponse>
    {

        readonly ICustomerRepresentativeWriteRepository _customerRepresentativeWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerRepresentativeHandler(ICustomerRepresentativeWriteRepository customerRepresentativeWriteRepository, IMapper mapper)
        {
            _customerRepresentativeWriteRepository = customerRepresentativeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerRepresentativeResponse> Handle(CreateCustomerRepresentativeRequest request, CancellationToken cancellationToken)
        {
            var customerRepresentative = _mapper.Map<T.CustomerManagement.Customers.CustomerRepresentative>(request);
            await _customerRepresentativeWriteRepository.AddAsync(customerRepresentative);
            await _customerRepresentativeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerRepresentativeResponse>(customerRepresentative);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
