using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Update
{
    public class UpdateCustomerActivityKindHandler : IRequestHandler<UpdateCustomerActivityKindRequest, UpdateCustomerActivityKindResponse>
    {
        readonly ICustomerActivityKindReadRepository _customerActivityKindReadRepository;
        readonly ICustomerActivityKindWriteRepository _customerActivityKindWriteRepository;
        readonly IMapper _mapper;
        public UpdateCustomerActivityKindHandler(ICustomerActivityKindReadRepository customerActivityKindReadRepository, ICustomerActivityKindWriteRepository customerActivityKindWriteRepository, IMapper mapper)
        {

            _customerActivityKindReadRepository = customerActivityKindReadRepository;
            _customerActivityKindWriteRepository = customerActivityKindWriteRepository;
            _mapper = mapper;

        }
        public async Task<UpdateCustomerActivityKindResponse> Handle(UpdateCustomerActivityKindRequest request, CancellationToken cancellationToken)
        {
            var customeractivitykind = await _customerActivityKindReadRepository.GetByIdAsync(request.Id);
            customeractivitykind = _mapper.Map(request, customeractivitykind);
            await _customerActivityKindWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerActivityKindResponse>(customeractivitykind);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
