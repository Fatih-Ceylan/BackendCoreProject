using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerGroup.Delete
{
    public  class DeleteCustomerGroupHandler : IRequestHandler<DeleteCustomerGroupRequest, DeleteCustomerGroupResponse>
    {
        readonly ICustomerGroupWriteRepository _customerGroupWriteRepository;
        public DeleteCustomerGroupHandler(ICustomerGroupWriteRepository customerGroupWriteRepository)
        {
            _customerGroupWriteRepository = customerGroupWriteRepository;
        }

        public async  Task<DeleteCustomerGroupResponse> Handle(DeleteCustomerGroupRequest request, CancellationToken cancellationToken)
        {
            await _customerGroupWriteRepository.SoftDeleteAsync(request.Id);
            await _customerGroupWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
