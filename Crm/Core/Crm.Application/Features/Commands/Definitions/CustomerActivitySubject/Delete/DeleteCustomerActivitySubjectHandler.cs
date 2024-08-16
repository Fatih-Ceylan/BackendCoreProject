using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Delete
{
    public  class DeleteCustomerActivitySubjectHandler : IRequestHandler<DeleteCustomerActivitySubjectRequest,DeleteCustomerActivitySubjectResponse>
    {
        readonly ICustomerActivitySubjectWriteRepository  _customerActivitySubjectWriteRepository;

        public DeleteCustomerActivitySubjectHandler(ICustomerActivitySubjectWriteRepository  customerActivitySubjectWriteRepository)
        {
            _customerActivitySubjectWriteRepository = customerActivitySubjectWriteRepository;
        }
        public async Task<DeleteCustomerActivitySubjectResponse> Handle(DeleteCustomerActivitySubjectRequest request, CancellationToken cancellationToken)
        {
            await _customerActivitySubjectWriteRepository.SoftDeleteAsync(request.Id);
            await _customerActivitySubjectWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
