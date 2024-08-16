using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSector.Delete
{
    public class DeleteCustomerSectorHandler : IRequestHandler<DeleteCustomerSectorRequest, DeleteCustomerSectorResponse>
    {
        readonly ICustomerSectorWriteRepository _customerSectorWriteRepository;

        public DeleteCustomerSectorHandler(ICustomerSectorWriteRepository customerSectorWriteRepository)
        {
            _customerSectorWriteRepository = customerSectorWriteRepository;
        }

        public async Task<DeleteCustomerSectorResponse> Handle(DeleteCustomerSectorRequest request, CancellationToken cancellationToken)
        {
            await _customerSectorWriteRepository.SoftDeleteAsync(request.Id);
            await _customerSectorWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}