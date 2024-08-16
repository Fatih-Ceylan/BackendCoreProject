using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerStatus.Delete
{
    public class DeleteCustomerStatusHandler : IRequestHandler<DeleteCustomerStatusRequest, DeleteCustomerStatusResponse>
    {
        readonly ICustomerStatusWriteRepository _customerStatusWriteRepository;

        public DeleteCustomerStatusHandler(ICustomerStatusWriteRepository customerStatusWriteRepository)
        {
            _customerStatusWriteRepository = customerStatusWriteRepository;
        }

        public async Task<DeleteCustomerStatusResponse> Handle(DeleteCustomerStatusRequest request, CancellationToken cancellationToken)
        {
            await _customerStatusWriteRepository.SoftDeleteAsync(request.Id);
            await _customerStatusWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
