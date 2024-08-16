using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Delete
{
    public class DeleteCustomerActivityTypeHandler : IRequestHandler<DeleteCustomerActivityTypeRequest, DeleteCustomerActivityTypeResponse>
    {
        readonly ICustomerActivityTypeWriteRepository _customerActivityTypeWriteRepository;


        public DeleteCustomerActivityTypeHandler(ICustomerActivityTypeWriteRepository customerActivityTypeWriteRepository)
        {
            _customerActivityTypeWriteRepository = customerActivityTypeWriteRepository;

        }

        public async Task<DeleteCustomerActivityTypeResponse> Handle(DeleteCustomerActivityTypeRequest request, CancellationToken cancellationToken)
        {
            await _customerActivityTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _customerActivityTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
