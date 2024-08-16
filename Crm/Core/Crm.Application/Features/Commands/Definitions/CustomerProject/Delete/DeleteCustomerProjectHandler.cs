using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerProject.Delete
{
    public class DeleteCustomerProjectHandler : IRequestHandler<DeleteCustomerProjectRequest, DeleteCustomerProjectResponse>
    {

        readonly ICustomerProjectWriteRepository _customerProjectWriteRepository;

        public DeleteCustomerProjectHandler(ICustomerProjectWriteRepository customerProjectWriteRepository)
        {
            _customerProjectWriteRepository = customerProjectWriteRepository;
        }

        public async Task<DeleteCustomerProjectResponse> Handle(DeleteCustomerProjectRequest request, CancellationToken cancellationToken)
        {
            await _customerProjectWriteRepository.SoftDeleteAsync(request.Id);
            await _customerProjectWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
