using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerType.Delete
{
    public class DeleteCustomerTypeHandler : IRequestHandler<DeleteCustomerTypeRequest, DeleteCustomerTypeResponse>
    {
        readonly ICustomerTypeWriteRepository _customerTypeWriteRepository;
        public DeleteCustomerTypeHandler(ICustomerTypeWriteRepository customerTypeWriteRepository)
        {
            _customerTypeWriteRepository = customerTypeWriteRepository;
        }

        public async Task<DeleteCustomerTypeResponse> Handle(DeleteCustomerTypeRequest request, CancellationToken cancellationToken)
        {
            await _customerTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _customerTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
