using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions.Files;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.Company.Create
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        readonly ICompanyWriteRepository _companyWriteRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly ICompanyFileWriteRepository _companyFileWriteRepository;
        readonly IBranchWriteRepository _branchWriteRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly ICompanyLicenseWriteRepository _companyLicenseWriteRepository;
        readonly ICompanyAddressWriteRepository _companyAddressWriteRepository;

        public CreateCompanyHandler(ICompanyWriteRepository companyWriteRepository, IMapper mapper, IStorageService storageService, ICompanyFileWriteRepository companyFileWriteRepository, IBranchWriteRepository branchWriteRepository, ICompanyReadRepository companyReadRepository, ICompanyLicenseWriteRepository companyLicenseWriteRepository, ICompanyAddressWriteRepository companyAddressWriteRepository)
        {
            _companyWriteRepository = companyWriteRepository;
            _mapper = mapper;
            _storageService = storageService;
            _companyFileWriteRepository = companyFileWriteRepository;
            _branchWriteRepository = branchWriteRepository;
            _companyReadRepository = companyReadRepository;
            _companyLicenseWriteRepository = companyLicenseWriteRepository;
            _companyAddressWriteRepository = companyAddressWriteRepository;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var mainCompany = _companyReadRepository.GetWhere(mc => mc.MainCompanyId == null).FirstOrDefault();
            if (mainCompany == null)
                throw new Exception("Your parent company is not registered in the system!");

            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.FileOptions?.Count > 0)
                uploadedDatas = await _storageService.UploadAsync("Company-Files", request.FileOptions);

            T.Company company = _mapper.Map<T.Company>(request);
            company.LogoPath = uploadedDatas?.Select(t => t.pathOrContainerName).FirstOrDefault();
            company.MainCompanyId = mainCompany.Id;
            company.MasterCompanyIdFromPlatform = mainCompany.MasterCompanyIdFromPlatform;
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

            createdResponse.MessageList =
            [
                "Company Added Success.",
                "The process of assigning licensed modules to the company was successfully.",
            ]; 
            if (request.CompanyAddresses != null)
            {
                createdResponse.MessageList.Add("Company Addresses added successfully.");
            }

            T.Branch branch = new();
            branch.CompanyId = company.Id;
            branch.Code = "0001";
            branch.Name = "Merkez Şube";
            branch.AuthorizedFullName = company.AuthorizedFullName;
            branch.PhoneNumber = company.PhoneNumber;
            branch.Email = company.Email;

            branch = await _branchWriteRepository.AddAsync(branch);
            await _branchWriteRepository.SaveAsync();
            createdResponse.MessageList.Add("Center Branch Added Success.");

            return createdResponse;
        }
    }
}