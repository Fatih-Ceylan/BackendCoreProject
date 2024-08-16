using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.DeletingEmployeesLabels
{
    public class DeletingEmployeesLabelsHandler : IRequestHandler<DeletingEmployeesLabelsRequest, DeletingEmployeesLabelsResponse>
    {
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IMapper _mapper;

        public DeletingEmployeesLabelsHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository, IEmployeeLabelReadRepository employeeLabelReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _mapper = mapper;
            _employeeReadRepository = employeeReadRepository;
            _employeeLabelReadRepository = employeeLabelReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<DeletingEmployeesLabelsResponse> Handle(DeletingEmployeesLabelsRequest request, CancellationToken cancellationToken)
        {

            var employees = await _employeeReadRepository.GetAllDeletedStatusIncluding([e => e.EmployeeLabels]).ToListAsync();
            var groupEmpLabelVM = new List<GroupEmployeeLabelVM>();
            foreach (var employeeId in request.EmployeesId)
            {
                var employee = employees.FirstOrDefault(e => e.Id == Guid.Parse(employeeId));

                if (employee != null)
                {
                    employee.EmployeeLabels.Clear();
                }

                await _employeeWriteRepository.SaveAsync();

            }
            return new()
            {
                Employees = groupEmpLabelVM,
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}
