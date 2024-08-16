using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Update
{
    public class UpdateCustomerActivityStatusHandler : IRequestHandler<UpdateCustomerActivityStatusRequest, UpdateCustomerActivityStatusResponse>
    {
        readonly ICustomerActivityStatusReadRepository _customerActivityStatusReadRepository;
        readonly ICustomerActivityStatusWriteRepository _customerActivityStatusWriteRepository;
        readonly IMapper _mapper;
        public UpdateCustomerActivityStatusHandler(ICustomerActivityStatusReadRepository customerActivityStatusReadRepository, ICustomerActivityStatusWriteRepository customerActivityStatusWriteRepository, IMapper mapper)
        {
            _customerActivityStatusReadRepository = customerActivityStatusReadRepository;
            _customerActivityStatusWriteRepository = customerActivityStatusWriteRepository;
            _mapper = mapper;

        }
        public async Task<UpdateCustomerActivityStatusResponse> Handle(UpdateCustomerActivityStatusRequest request, CancellationToken cancellationToken)
        {
            var customeractivitystatus = await _customerActivityStatusReadRepository.GetByIdAsync(request.Id);
            customeractivitystatus = _mapper.Map(request, customeractivitystatus);
            await _customerActivityStatusWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerActivityStatusResponse>(customeractivitystatus);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
