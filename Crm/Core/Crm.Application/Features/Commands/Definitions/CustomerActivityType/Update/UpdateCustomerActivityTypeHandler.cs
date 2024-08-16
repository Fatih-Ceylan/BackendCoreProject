using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Update
{
    public class UpdateCustomerActivityTypeHandler : IRequestHandler<UpdateCustomerActivityTypeRequest, UpdateCustomerActivityTypeResponse>
    {
        readonly ICustomerActivityTypeWriteRepository _customerActivityTypeWriteRepository;
        readonly ICustomerActivityTypeReadRepository _customerActivityTypeReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerActivityTypeHandler(ICustomerActivityTypeWriteRepository customerActivityTypeWriteRepository, ICustomerActivityTypeReadRepository customerActivityTypeReadRepository, IMapper mapper)
        {
            _customerActivityTypeWriteRepository = customerActivityTypeWriteRepository;
            _customerActivityTypeReadRepository = customerActivityTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerActivityTypeResponse> Handle(UpdateCustomerActivityTypeRequest request, CancellationToken cancellationToken)
        {
            var customeractivitytype = await _customerActivityTypeReadRepository.GetByIdAsync(request.Id);
            customeractivitytype = _mapper.Map(request, customeractivitytype);
            await _customerActivityTypeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerActivityTypeResponse>(customeractivitytype);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
