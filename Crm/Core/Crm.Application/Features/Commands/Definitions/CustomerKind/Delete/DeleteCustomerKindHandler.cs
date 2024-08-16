using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerKind.Delete
{
    public class DeleteCustomerKindHandler : IRequestHandler<DeleteCustomerKindRequest, DeleteCustomerKindResponse>
    {
        readonly ICustomerKindWriteRepository _customerKindWriteRepository;

        public DeleteCustomerKindHandler(ICustomerKindWriteRepository customerKindWriteRepository)
        {
            _customerKindWriteRepository = customerKindWriteRepository;
        }

        public async Task<DeleteCustomerKindResponse> Handle(DeleteCustomerKindRequest request, CancellationToken cancellationToken)
        {
            await _customerKindWriteRepository.SoftDeleteAsync(request.Id);
            await _customerKindWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
