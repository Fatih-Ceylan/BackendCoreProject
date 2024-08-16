using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Delete
{
    public class DeleteCustomerRepresentativeHandler : IRequestHandler<DeleteCustomerRepresentativeRequest, DeleteCustomerRepresentativeResponse>
    {
        readonly ICustomerRepresentativeWriteRepository _customerRepresentativeWriteRepository;
        public DeleteCustomerRepresentativeHandler(ICustomerRepresentativeWriteRepository customerRepresentativeWriteRepository)
        {
            _customerRepresentativeWriteRepository = customerRepresentativeWriteRepository;
        }

        public async  Task<DeleteCustomerRepresentativeResponse> Handle(DeleteCustomerRepresentativeRequest request, CancellationToken cancellationToken)
        {
            await _customerRepresentativeWriteRepository.SoftDeleteAsync(request.Id);
            await _customerRepresentativeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
