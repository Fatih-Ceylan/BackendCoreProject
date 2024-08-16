using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.DepartmentIsActiveStatus
{
    public class DepartmentIsActiveStatusHandler : IRequestHandler<DepartmentIsActiveStatusRequest, DepartmentIsActiveStatusResponse>
    {
        readonly IDepartmentWriteRepository _departmentWriteRepository;
        readonly IDepartmentReadRepository _departmentReadRepository;
        readonly IMapper _mapper;

        public DepartmentIsActiveStatusHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _departmentWriteRepository = departmentWriteRepository;

            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentIsActiveStatusResponse> Handle(DepartmentIsActiveStatusRequest request, CancellationToken cancellationToken)
        {
            var departmentIsActive = await _departmentReadRepository.GetByIdAsync(request.Id);
            departmentIsActive.isActive = request.isActive;
            _mapper.Map(request.isActive, departmentIsActive.isActive);
            await _departmentWriteRepository.SaveAsync();
            var updatedResponse = new DepartmentIsActiveStatusResponse
            {
                Id = departmentIsActive.Id.ToString(),
                IsActive = (bool)departmentIsActive.isActive,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };


            return updatedResponse;
        }
    }
}
