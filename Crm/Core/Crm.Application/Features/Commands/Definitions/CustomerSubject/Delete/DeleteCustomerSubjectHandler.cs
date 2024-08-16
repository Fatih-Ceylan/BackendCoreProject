using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSubject.Delete
{
    public class DeleteCustomerSubjectHandler : IRequestHandler<DeleteCustomerSubjectRequest, DeleteCustomerSubjectResponse>
    {
        readonly ICustomerSubjectWriteRepository _customerSubjectWriteRepository;

        public DeleteCustomerSubjectHandler(ICustomerSubjectWriteRepository customerSubjectWriteRepository)
        {
            _customerSubjectWriteRepository = customerSubjectWriteRepository;
        }

        public async Task<DeleteCustomerSubjectResponse> Handle(DeleteCustomerSubjectRequest request, CancellationToken cancellationToken)
        {
            await _customerSubjectWriteRepository.SoftDeleteAsync(request.Id);
            await _customerSubjectWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
