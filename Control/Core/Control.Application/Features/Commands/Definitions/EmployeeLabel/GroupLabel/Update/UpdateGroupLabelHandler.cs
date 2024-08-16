using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;
namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Update
{
    public class UpdateGroupLabelHandler : IRequestHandler<UpdateGroupLabelRequest, UpdateGroupLabelResponse>
    {
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IMapper _mapper;

        public UpdateGroupLabelHandler(IMapper mapper, IEmployeeReadRepository employeeReadRepository, IEmployeeLabelReadRepository employeeLabelReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _mapper = mapper;
            _employeeReadRepository = employeeReadRepository;
            _employeeLabelReadRepository = employeeLabelReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<UpdateGroupLabelResponse> Handle(UpdateGroupLabelRequest request, CancellationToken cancellationToken)
        {
            var employees = await _employeeReadRepository.GetAllDeletedStatusDesc().Include(e => e.EmployeeLabels).ToListAsync();
            var groupEmpLabelVM = new List<GroupEmployeeLabelVM>();

            foreach (var employeeId in request.EmployeesId)
            {
                var employee = employees.FirstOrDefault(e => e.Id == Guid.Parse(employeeId));

                if (employee != null)
                {
                    employee.EmployeeLabels.Clear();

                    foreach (var employeeLabelId in request.EmployeeLabelsId)
                    {
                        var employeeLabel = await _employeeLabelReadRepository.GetByIdAsync(employeeLabelId);

                        if (employeeLabel != null)
                        {
                            employee.EmployeeLabels.Add(employeeLabel);

                            var newEmp = new GroupEmployeeLabelVM
                            {
                                EmployeeId = employeeId,
                                EmployeeName = employee.FullName,
                                LabelId = employeeLabel.Id.ToString(),
                                LabelName = employeeLabel.Name,
                            };

                            groupEmpLabelVM.Add(newEmp);
                        }
                    }

                    _employeeWriteRepository.Update(employee);
                }
            }

            await _employeeWriteRepository.SaveAsync();

            return new UpdateGroupLabelResponse
            {
                Employees = groupEmpLabelVM,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }


    }
}
