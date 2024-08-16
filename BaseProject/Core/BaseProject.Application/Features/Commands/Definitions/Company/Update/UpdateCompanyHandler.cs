using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions.Files;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.Company.Update
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly ICompanyFileWriteRepository _companyFileWriteRepository;
        readonly ICompanyLicenseReadRepository _companyLicenseReadRepository;
        readonly ICompanyLicenseWriteRepository _companyLicenseWriteRepository;
        readonly ICompanyAddressWriteRepository _companyAddressWriteRepository;
        readonly ICompanyAddressReadRepository _companyAddressReadRepository;

        public UpdateCompanyHandler(ICompanyWriteRepository companyWriteRepository, IMapper mapper, ICompanyReadRepository companyReadRepository, IStorageService storageService, ICompanyFileWriteRepository companyFileWriteRepository, ICompanyLicenseReadRepository companyLicenseReadRepository, ICompanyLicenseWriteRepository companyLicenseWriteRepository, ICompanyAddressWriteRepository companyAddressWriteRepository, ICompanyAddressReadRepository companyAddressReadRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
            _storageService = storageService;
            _companyFileWriteRepository = companyFileWriteRepository;
            _companyLicenseReadRepository = companyLicenseReadRepository;
            _companyLicenseWriteRepository = companyLicenseWriteRepository;
            _companyAddressWriteRepository = companyAddressWriteRepository;
            _companyAddressReadRepository = companyAddressReadRepository;
        }

        public async Task<UpdateCompanyResponse> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (!string.IsNullOrEmpty(request.FileOptions[0].Base64String))
            {
                uploadedDatas = await _storageService.UploadAsync("Company-Files", request.FileOptions);
            }
            T.Company company = await _companyReadRepository.GetByIdAsync(request.Id);
            if (uploadedDatas != null)
            {
                company.LogoPath = uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault();
            }
            company = _mapper.Map(request, company);
            company.CompanyLicenses.Clear();
            company.CompanyAddresses.Clear();

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

            var updatedResponse = _mapper.Map<UpdateCompanyResponse>(company);
            updatedResponse.MessageList = new();
            await _companyWriteRepository.SaveAsync();

            var companyLicenses = _companyLicenseReadRepository.GetAll(false).Where(cl => cl.CompanyId == company.Id).ToList();

            if (companyLicenses != null)
            {
                _companyLicenseWriteRepository.HardDeleteRange(companyLicenses);
                await _companyLicenseWriteRepository.SaveAsync();
            }

            companyLicenses = null;
            companyLicenses = _mapper.Map<List<T.CompanyLicense>>(request.CompanyLicenses);
            companyLicenses.ForEach(ca => ca.CompanyId = company.Id);

            await _companyLicenseWriteRepository.AddRangeAsync(companyLicenses);
            await _companyLicenseWriteRepository.SaveAsync();

            updatedResponse.MessageList =
            [
               "Company updated Success.",
                "The process of assigning licensed modules to the company was successfully.",
            ];

            if (request.CompanyAddresses.Count > 0)
            {
                var companyAddresses = _companyAddressReadRepository.GetAll(false).Where(cl => cl.CompanyId == company.Id).ToList();

                if (companyAddresses != null)
                {
                    _companyAddressWriteRepository.HardDeleteRange(companyAddresses);
                    await _companyAddressWriteRepository.SaveAsync();
                }

                companyAddresses = null;
                companyAddresses = _mapper.Map<List<T.CompanyAddress>>(request.CompanyAddresses);
                companyAddresses.ForEach(ca => ca.CompanyId = company.Id);

                await _companyAddressWriteRepository.AddRangeAsync(companyAddresses);
                await _companyAddressWriteRepository.SaveAsync();

                updatedResponse.MessageList.Add("Company Addresses updated successfully.");
            }

            return updatedResponse;
        }
    }
}