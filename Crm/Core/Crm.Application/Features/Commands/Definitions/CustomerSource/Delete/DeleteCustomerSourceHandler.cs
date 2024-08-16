using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSource.Delete
{
    internal class DeleteCustomerSourceHandler : IRequestHandler<DeleteCustomerSourceRequest, DeleteCustomerSourceResponse>
    {
        readonly ICustomerSourceWriteRepository _customerSourceWriteRepository;

        public DeleteCustomerSourceHandler(ICustomerSourceWriteRepository customerSourceWriteRepository)
        {
            _customerSourceWriteRepository = customerSourceWriteRepository;
        }

        public async Task<DeleteCustomerSourceResponse> Handle(DeleteCustomerSourceRequest request, CancellationToken cancellationToken)
        {
            await _customerSourceWriteRepository.SoftDeleteAsync(request.Id);
            await _customerSourceWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
