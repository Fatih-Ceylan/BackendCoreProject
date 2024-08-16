using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.EmployeeFile.Create
{
    public class CreateEmployeeFileHandler : IRequestHandler<CreateEmployeeFileRequest, CreateEmployeeFileResponse>
    {
        readonly IEmployeeFileWriteRepository _employeeFileWriteRepository;
        readonly IStorageService _storageService;
        readonly IMapper _mapper;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;

        public CreateEmployeeFileHandler(IEmployeeFileWriteRepository employeeFileWriteRepository, IStorageService storageService, IMapper mapper, IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeFileWriteRepository = employeeFileWriteRepository;
            _storageService = storageService;
            _mapper = mapper;
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<CreateEmployeeFileResponse> Handle(CreateEmployeeFileRequest request, CancellationToken cancellationToken)
        {
            var uploadedDatas = await _storageService.UploadAsync("Employee-Files", request.Files);

            T.Employee employee = await _employeeReadRepository.GetByIdAsync(request.EmployeeId);

            await _employeeFileWriteRepository.AddRangeAsync(uploadedDatas.Select(r => new T.Files.EmployeeFile()
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Employees = new List<T.Employee>() { employee }
            }).ToList());
            await _employeeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}
