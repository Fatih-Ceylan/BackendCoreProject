using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.Delete
{
    public class DeleteEmployeeLabelHandler : IRequestHandler<DeleteEmployeeLabelRequest, DeleteEmployeeLabelResponse>
    {
        readonly IEmployeeLabelWriteRepository _employeeLabelWriteRepository;

        public DeleteEmployeeLabelHandler(IEmployeeLabelWriteRepository employeeLabelWriteRepository)
        {
            _employeeLabelWriteRepository = employeeLabelWriteRepository;
        }

        public async Task<DeleteEmployeeLabelResponse> Handle(DeleteEmployeeLabelRequest request, CancellationToken cancellationToken)
        {
            await _employeeLabelWriteRepository.SoftDeleteAsync(request.Id);
            await _employeeLabelWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
