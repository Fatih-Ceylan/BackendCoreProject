using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Create
{
    public class CreateCustomerActivityTypeHandler : IRequestHandler<CreateCustomerActivityTypeRequest, CreateCustomerActivityTypeResponse>
    {
        readonly ICustomerActivityTypeWriteRepository _customerActivityTypeWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerActivityTypeHandler(ICustomerActivityTypeWriteRepository customerActivityTypeWriteRepository, IMapper mapper)
        {
            _customerActivityTypeWriteRepository = customerActivityTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerActivityTypeResponse> Handle(CreateCustomerActivityTypeRequest request, CancellationToken cancellationToken)
        {
            var customeractivitytype = _mapper.Map<T.ActivitiesManagement.Activities.CustomerActivityType>(request);
            customeractivitytype = await _customerActivityTypeWriteRepository.AddAsync(customeractivitytype);
            await _customerActivityTypeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerActivityTypeResponse>(customeractivitytype);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
