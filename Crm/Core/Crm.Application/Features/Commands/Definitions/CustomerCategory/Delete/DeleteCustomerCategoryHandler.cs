using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerCategory.Delete
{
    public class DeleteCustomerCategoryHandler : IRequestHandler<DeleteCustomerCategoryRequest, DeleteCustomerCategoryResponse>
    {
        readonly ICustomerCategoryWriteRepository _customerCategoryWriteRepository;
        public DeleteCustomerCategoryHandler(ICustomerCategoryWriteRepository customerCategoryWriteRepository)
        {
            _customerCategoryWriteRepository = customerCategoryWriteRepository;
        }
        public async Task<DeleteCustomerCategoryResponse> Handle(DeleteCustomerCategoryRequest request, CancellationToken cancellationToken)
        {
            await _customerCategoryWriteRepository.SoftDeleteAsync(request.Id);
            await _customerCategoryWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
