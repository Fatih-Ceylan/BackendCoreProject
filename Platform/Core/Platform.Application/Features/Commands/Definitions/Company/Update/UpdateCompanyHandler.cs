using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions.Files;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.Company.Update
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly ICompanyFileWriteRepository _companyFileWriteRepository;

        public UpdateCompanyHandler(ICompanyWriteRepository companyWriteRepository, IMapper mapper, ICompanyReadRepository companyReadRepository, IStorageService storageService, ICompanyFileWriteRepository companyFileWriteRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
            _storageService = storageService;
            _companyFileWriteRepository = companyFileWriteRepository;
        }

        public async Task<UpdateCompanyResponse> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.Files?.Count > 0)
                uploadedDatas = await _storageService.UploadAsync("Company-Files", request.Files);

            T.Company company = await _companyReadRepository.GetByIdAsync(request.Id);
            company.LogoPath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : company.LogoPath;
            company = _mapper.Map(request, company);

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

            var updatedResponse = _mapper.Map<UpdateCompanyResponse>(company);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
