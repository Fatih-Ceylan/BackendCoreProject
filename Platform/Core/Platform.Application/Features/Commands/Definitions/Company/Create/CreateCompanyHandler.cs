using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions.Files;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.Company.Create
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly ICompanyFileWriteRepository _companyFileWriteRepository;

        readonly ILogger<CreateCompanyHandler> _logger;

        public CreateCompanyHandler(ICompanyWriteRepository companyWriteRepository, IMapper mapper, IStorageService storageService, ICompanyFileWriteRepository companyFileWriteRepository, ILogger<CreateCompanyHandler> logger)
        {
            _companyWriteRepository = companyWriteRepository;
            _mapper = mapper;
            _storageService = storageService;
            _companyFileWriteRepository = companyFileWriteRepository;
            _logger = logger;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.Files?.Count > 0)
                uploadedDatas = await _storageService.UploadAsync("Company-Files", request.Files);

            T.Company company = _mapper.Map<T.Company>(request);
            company.LogoPath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
            company.UrlPath = company.BaseDbName;
            company.BaseDbName = $"{company.BaseDbName}_base";

            company = await _companyWriteRepository.AddAsync(company);
            var createdResponse = _mapper.Map<CreateCompanyResponse>(company);

            if (uploadedDatas != null)
            {
                await _companyFileWriteRepository.AddRangeAsync(uploadedDatas.Select(r => new T.Files.CompanyFile()
                {
                    FileName = r.fileName,
                    Path = r.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    Companies = new List<T.Company>() { company }
                }).ToList());
            }
            await _companyWriteRepository.SaveAsync();
            createdResponse.MessageList = new();
            createdResponse.MessageList.Add(CommandResponseMessage.AddedSuccess.ToString());

            _logger.LogInformation("Company Created....");
            return createdResponse;
        }
    }
}