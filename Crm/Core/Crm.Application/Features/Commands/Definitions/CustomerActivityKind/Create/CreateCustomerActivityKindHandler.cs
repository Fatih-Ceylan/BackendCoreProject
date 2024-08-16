using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Create
{
    public class CreateCustomerActivityKindHandler : IRequestHandler<CreateCustomerActivityKindRequest, CreateCustomerActivityKindResponse>
    {
        readonly ICustomerActivityKindWriteRepository _customerActivityKindWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerActivityKindHandler(ICustomerActivityKindWriteRepository customerActivityKindWriteRepository, IMapper mapper)
        {

            _customerActivityKindWriteRepository = customerActivityKindWriteRepository;
            _mapper = mapper;

        }
        public async Task<CreateCustomerActivityKindResponse> Handle(CreateCustomerActivityKindRequest request, CancellationToken cancellationToken)
        {
            var customeractivitykind = _mapper.Map<T.ActivitiesManagement.Activities.CustomerActivityKind>(request);

            customeractivitykind = await _customerActivityKindWriteRepository.AddAsync(customeractivitykind);
            await _customerActivityKindWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerActivityKindResponse>(customeractivitykind);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
