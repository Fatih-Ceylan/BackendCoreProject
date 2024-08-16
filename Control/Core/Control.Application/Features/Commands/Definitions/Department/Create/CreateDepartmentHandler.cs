using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.Department.Create
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentRequest, CreateDepartmentResponse>
    {
        readonly IDepartmentWriteRepository _departmentWriteRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository _baseDepartmentReadRepository;
        readonly ILocationReadRepository _locationReadRepository;
        readonly Repositories.ReadRepository.IDepartmentReadRepository _departmentReadRepository;

        public CreateDepartmentHandler(IDepartmentWriteRepository departmentWriteRepository, IMapper mapper, BaseProject.Application.Repositories.ReadRepository.Definitions.IDepartmentReadRepository baseDepartmentReadRepository, ILocationReadRepository locationReadRepository, Repositories.ReadRepository.IDepartmentReadRepository departmentReadRepository)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _mapper = mapper;
            _baseDepartmentReadRepository = baseDepartmentReadRepository;
            _locationReadRepository = locationReadRepository;
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<CreateDepartmentResponse> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<T.Department>(request);

            var baseDepartment = await _baseDepartmentReadRepository.GetByIdAsync(request.BaseDepartmentId);
            var location = await _locationReadRepository.GetByIdAsync(request.LocationId);
            var departmentList =  _departmentReadRepository.GetAllDeletedStatus(false,false).ToList();
            var isMatching = departmentList.Any(department => department.BaseDepartmentId == Guid.Parse(request.BaseDepartmentId));



            if (isMatching)
            {
                var errorResponse = new CreateDepartmentResponse
                {
                    Message = "Bu departmana lokasyon atanmıştır",

                };
                return errorResponse;
            }
            else
            {

                department = await _departmentWriteRepository.AddAsync(department);
                await _departmentWriteRepository.SaveAsync();

                var createdResponse = _mapper.Map<CreateDepartmentResponse>(department);
                createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

                createdResponse.BaseDepartmentName = baseDepartment.Name;
                createdResponse.LocationName = location.Name;

                return createdResponse;
            }

        }
    }
}
