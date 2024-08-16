using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EmployeeType.Update
{
    public class UpdateEmployeeTypeHandler : IRequestHandler<UpdateEmployeeTypeRequest, UpdateEmployeeTypeResponse>
    {
        readonly IEmployeeTypeWriteRepository _employeeTypeWriteRepository;
        readonly IEmployeeTypeReadRepository _employeeTypeReadRepository;
        readonly IMapper _mapper;

        public UpdateEmployeeTypeHandler(IEmployeeTypeWriteRepository employeeTypeWriteRepository, IEmployeeTypeReadRepository employeeTypeReadRepository, IMapper mapper)
        {
            _employeeTypeWriteRepository = employeeTypeWriteRepository;
            _employeeTypeReadRepository = employeeTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateEmployeeTypeResponse> Handle(UpdateEmployeeTypeRequest request, CancellationToken cancellationToken)
        {
            var employeeType = await _employeeTypeReadRepository.GetByIdAsync(request.Id);
            employeeType = _mapper.Map(request, employeeType);
            await _employeeTypeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateEmployeeTypeResponse>(employeeType);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
