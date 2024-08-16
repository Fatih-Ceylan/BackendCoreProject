using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerGroup.Create
{
    public class CreateCustomerGroupHandler : IRequestHandler<CreateCustomerGroupRequest, CreateCustomerGroupResponse>
    {
        readonly ICustomerGroupWriteRepository  _customerGroupWriteRepository;
        readonly IMapper _mapper;
        public CreateCustomerGroupHandler(ICustomerGroupWriteRepository customerGroupWriteRepository, IMapper mapper)
        {
            _customerGroupWriteRepository = customerGroupWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateCustomerGroupResponse> Handle(CreateCustomerGroupRequest request, CancellationToken cancellationToken)
        {
            var customergroup = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers.CustomerGroup>(request);

            customergroup = await _customerGroupWriteRepository.AddAsync(customergroup);
            await _customerGroupWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerGroupResponse>(customergroup);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
