using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using GCrm.Application.Repositories.WriteRepository.Files;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects;

namespace GCrm.Application.Features.Commands.Definitions.Project.Create
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectRequest, CreateProjectResponse>
    {
        readonly IProjectWriteRepository _projectWriteRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly IProjectFileWriteRepository _projectFileWriteRepository;

        public CreateProjectHandler(IProjectWriteRepository projectWriteRepository, IMapper mapper, IStorageService storageService, IProjectFileWriteRepository projectFileWriteRepository)
        {
            _projectWriteRepository = projectWriteRepository;
            _mapper = mapper;
            _storageService = storageService;
            _projectFileWriteRepository = projectFileWriteRepository;
        }
        public async Task<CreateProjectResponse> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<T.Project>(request);

            project = await _projectWriteRepository.AddAsync(project);


            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.Files != null && request.Files.Count > 0)
                uploadedDatas = await _storageService.UploadAsync("Project-Files", request.Files);


            if (uploadedDatas != null)
            {
                await _projectFileWriteRepository.AddRangeAsync(uploadedDatas.Select(r => new T.Files.ProjectFiles()
                {
                    FileName = r.fileName,
                    Path = r.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    Projects = new List<T.Project>() { project }
                }).ToList());
            }

            await _projectWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProjectResponse>(project);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
