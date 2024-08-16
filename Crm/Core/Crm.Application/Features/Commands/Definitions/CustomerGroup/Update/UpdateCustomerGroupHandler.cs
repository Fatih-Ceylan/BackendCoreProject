using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerGroup.Update
{
    public class UpdateCustomerGroupHandler : IRequestHandler<UpdateCustomerGroupRequest, UpdateCustomerGroupResponse>
    {
        readonly ICustomerGroupWriteRepository  _customerGroupWriteRepository;
        readonly ICustomerGroupReadRepository  _customerGroupReadRepository;
        readonly IMapper _mapper;
        public UpdateCustomerGroupHandler(ICustomerGroupWriteRepository customerGroupWriteRepository, ICustomerGroupReadRepository customerGroupReadRepository, IMapper mapper)
        {
            _customerGroupWriteRepository = customerGroupWriteRepository;
            _customerGroupReadRepository = customerGroupReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateCustomerGroupResponse> Handle(UpdateCustomerGroupRequest request, CancellationToken cancellationToken)
        {
            var customergroup = await _customerGroupReadRepository.GetByIdAsync(request.Id);
            customergroup = _mapper.Map(request, customergroup);
            await _customerGroupWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerGroupResponse>(customergroup);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
