using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Create
{
    public class CreateCustomerActivityStatusHandler : IRequestHandler<CreateCustomerActivityStatusRequest, CreateCustomerActivityStatusResponse>
    {
        readonly ICustomerActivityStatusWriteRepository _customerActivityStatusWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerActivityStatusHandler(ICustomerActivityStatusWriteRepository customerActivityStatusWriteRepository, IMapper mapper)
        {
            _customerActivityStatusWriteRepository = customerActivityStatusWriteRepository;
            _mapper = mapper;

        }

        public async Task<CreateCustomerActivityStatusResponse> Handle(CreateCustomerActivityStatusRequest request, CancellationToken cancellationToken)
        {
            var customeractivitystatus = _mapper.Map<T.ActivitiesManagement.Activities.CustomerActivityStatus>(request);

            customeractivitystatus = await _customerActivityStatusWriteRepository.AddAsync(customeractivitystatus);
            await _customerActivityStatusWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerActivityStatusResponse>(customeractivitystatus);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
