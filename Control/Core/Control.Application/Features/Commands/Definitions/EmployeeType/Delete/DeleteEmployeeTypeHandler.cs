using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EmployeeType.Delete
{
    public class DeleteEmployeeTypeHandler : IRequestHandler<DeleteEmployeeTypeRequest, DeleteEmployeeTypeResponse>
    {
        readonly IEmployeeTypeWriteRepository _employeeTypeWriteRepository;

        public DeleteEmployeeTypeHandler(IEmployeeTypeWriteRepository employeeTypeWriteRepository)
        {
            _employeeTypeWriteRepository = employeeTypeWriteRepository;
        }

        public async Task<DeleteEmployeeTypeResponse> Handle(DeleteEmployeeTypeRequest request, CancellationToken cancellationToken)
        {
            await _employeeTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _employeeTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }

}
