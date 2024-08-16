using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EmployeeLabel.Update
{
    public class UpdateEmployeeLabelHandler : IRequestHandler<UpdateEmployeeLabelRequest, UpdateEmployeeLabelResponse>
    {
        readonly IEmployeeLabelWriteRepository _employeeLabelWriteRepository;
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IMapper _mapper;

        public UpdateEmployeeLabelHandler(IEmployeeLabelWriteRepository employeeLabelWriteRepository, IEmployeeLabelReadRepository employeeLabelReadRepository, IMapper mapper)
        {
            _employeeLabelWriteRepository = employeeLabelWriteRepository;
            _employeeLabelReadRepository = employeeLabelReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateEmployeeLabelResponse> Handle(UpdateEmployeeLabelRequest request, CancellationToken cancellationToken)
        {
            var employeeLabel = await _employeeLabelReadRepository.GetByIdAsync(request.Id);
            employeeLabel = _mapper.Map(request, employeeLabel);
            await _employeeLabelWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateEmployeeLabelResponse>(employeeLabel);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
