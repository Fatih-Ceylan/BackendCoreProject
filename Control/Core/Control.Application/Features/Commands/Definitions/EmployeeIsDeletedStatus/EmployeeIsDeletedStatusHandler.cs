using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.EmployeeIsDeletedStatus
{
    public class EmployeeIsDeletedStatusHandler : IRequestHandler<EmployeeIsDeletedStatusRequest, EmployeeIsDeletedStatusResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IMapper _mapper;

        public EmployeeIsDeletedStatusHandler(IEmployeeWriteRepository employeeWriteRepository, IEmployeeReadRepository employeeReadRepository, IMapper mapper)
        {
            _employeeWriteRepository = employeeWriteRepository;

            _employeeReadRepository = employeeReadRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeIsDeletedStatusResponse> Handle(EmployeeIsDeletedStatusRequest request, CancellationToken cancellationToken)
        {
            var employeeIsDeleted = await _employeeReadRepository.GetByIdAsync(request.Id);
            employeeIsDeleted.IsDeleted = request.isDeleted;
            _mapper.Map(request.isDeleted, employeeIsDeleted.IsDeleted);
            await _employeeWriteRepository.SaveAsync();
            var updatedResponse = new EmployeeIsDeletedStatusResponse
            {
                Id = employeeIsDeleted.Id.ToString(),
                IsDeleted = employeeIsDeleted.IsDeleted,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };


            return updatedResponse;
        }
    }
}
