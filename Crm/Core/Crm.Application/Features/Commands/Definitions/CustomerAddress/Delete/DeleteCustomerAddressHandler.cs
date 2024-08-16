using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerAddress.Delete
{
    public class DeleteCustomerAddressHandler : IRequestHandler<DeleteCustomerAddressRequest, DeleteCustomerAddressResponse>
    {
        readonly ICustomerAddressWriteRepository _customerAddressWriteRepository;

        public DeleteCustomerAddressHandler(ICustomerAddressWriteRepository customerAddressWriteRepository)
        {
            _customerAddressWriteRepository = customerAddressWriteRepository;
        }

        public async Task<DeleteCustomerAddressResponse> Handle(DeleteCustomerAddressRequest request, CancellationToken cancellationToken)
        {
            await _customerAddressWriteRepository.SoftDeleteAsync(request.Id);
            await _customerAddressWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}