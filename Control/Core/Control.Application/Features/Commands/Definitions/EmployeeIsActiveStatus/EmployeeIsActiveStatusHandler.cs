using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EmployeeIsActiveStatus
{
    public class EmployeeIsActiveStatusHandler : IRequestHandler<EmployeeIsActiveStatusRequest, EmployeeIsActiveStatusResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IMapper _mapper;

        public EmployeeIsActiveStatusHandler(IEmployeeWriteRepository employeeWriteRepository, IEmployeeReadRepository employeeReadRepository, IMapper mapper)
        {
            _employeeWriteRepository = employeeWriteRepository;
            
            _employeeReadRepository = employeeReadRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeIsActiveStatusResponse> Handle(EmployeeIsActiveStatusRequest request, CancellationToken cancellationToken)
        {
            var employeeIsActive = await _employeeReadRepository.GetByIdAsync(request.Id);
            employeeIsActive.isActive = request.isActive;
            _mapper.Map(request.isActive, employeeIsActive.isActive);
            await _employeeWriteRepository.SaveAsync();
            var updatedResponse = new EmployeeIsActiveStatusResponse
            {
                Id = employeeIsActive.Id.ToString(),
                IsActive = employeeIsActive.isActive,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };


            return updatedResponse;
        }
    }
}
