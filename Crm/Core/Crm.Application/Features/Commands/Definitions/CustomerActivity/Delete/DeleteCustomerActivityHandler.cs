using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivity.Delete
{
    public class DeleteCustomerActivityHandler : IRequestHandler<DeleteCustomerActivityRequest, DeleteCustomerActivityResponse>
    {
        readonly ICustomerActivityWriteRepository _customerActivityWriteRepository;

        public DeleteCustomerActivityHandler(ICustomerActivityWriteRepository customerActivityWriteRepository)
        {
            _customerActivityWriteRepository = customerActivityWriteRepository;
        }
        public async Task<DeleteCustomerActivityResponse> Handle(DeleteCustomerActivityRequest request, CancellationToken cancellationToken)
        {
            await _customerActivityWriteRepository.SoftDeleteAsync(request.Id);
            await _customerActivityWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
