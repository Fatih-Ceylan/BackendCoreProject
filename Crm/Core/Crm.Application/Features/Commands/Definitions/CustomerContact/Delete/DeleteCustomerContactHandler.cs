using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerContact.Delete
{
    public class DeleteCustomerContactHandler : IRequestHandler<DeleteCustomerContactRequest, DeleteCustomerContactResponse>
    {
        readonly ICustomerContactWriteRepository _customerContactWriteRepository;
        public DeleteCustomerContactHandler(ICustomerContactWriteRepository customerContactWriteRepository)
        {
            _customerContactWriteRepository = customerContactWriteRepository;
        }

        public async Task<DeleteCustomerContactResponse> Handle(DeleteCustomerContactRequest request, CancellationToken cancellationToken)
        {
            await _customerContactWriteRepository.SoftDeleteAsync(request.Id);
            await _customerContactWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
