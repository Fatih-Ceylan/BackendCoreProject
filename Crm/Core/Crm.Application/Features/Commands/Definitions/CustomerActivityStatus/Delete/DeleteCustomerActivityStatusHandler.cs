using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Delete
{
    public class DeleteCustomerActivityStatusHandler : IRequestHandler<DeleteCustomerActivityStatusRequest, DeleteCustomerActivityStatusResponse>
    {
        readonly ICustomerActivityStatusWriteRepository _customerActivityStatusWriteRepository;


        public DeleteCustomerActivityStatusHandler(ICustomerActivityStatusWriteRepository customerActivityStatusWriteRepository)
        {
            _customerActivityStatusWriteRepository = customerActivityStatusWriteRepository;


        }
        public async Task<DeleteCustomerActivityStatusResponse> Handle(DeleteCustomerActivityStatusRequest request, CancellationToken cancellationToken)
        {
            await _customerActivityStatusWriteRepository.SoftDeleteAsync(request.Id);
            await _customerActivityStatusWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
