using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Application.VMs.Definitions.License;
using Platform.Domain.Entities.Enums;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.License.Create
{
    public class CreateLicenseHandler : IRequestHandler<CreateLicenseRequest, CreateLicenseResponse>
    {
        readonly ILicenseReadRepository _licenseReadRepository;
        readonly ILicenseWriteRepository _licenseWriteRepository;
        readonly IMapper _mapper;
        readonly ILicenseTypeReadRepository _licenseTypeReadRepository;
        readonly ILicenseDetailWriteRepository _licenseDetailWriteRepository;
  
        public CreateLicenseHandler(ILicenseWriteRepository licenseWriteRepository, IMapper mapper, ILicenseTypeReadRepository licenseTypeReadRepository, ILicenseDetailWriteRepository licenseDetailWriteRepository, ILicenseReadRepository licenseReadRepository)
        {
            _licenseWriteRepository = licenseWriteRepository;
            _mapper = mapper;
            _licenseTypeReadRepository = licenseTypeReadRepository;
            _licenseDetailWriteRepository = licenseDetailWriteRepository;
            _licenseReadRepository = licenseReadRepository;
        }

        public async Task<CreateLicenseResponse> Handle(CreateLicenseRequest request, CancellationToken cancellationToken)
        {
            var lastLicense = _licenseReadRepository
                                  .GetWhere(l => l.CompanyId == Guid.Parse(request.CompanyId)
                                            && l.GModuleId == Guid.Parse(request.GModuleId)
                                            && l.ExpirationDate > request.StartDate)
                                  .FirstOrDefault();
            if (lastLicense != null && request.LicenseStatus == LicenseStatusEnum.BaseLicense)
            {
                throw new Exception($"You have a license for this module.License Key is {lastLicense.LicenseKey}.Please check.");
            }

            var licenseDetails = _mapper.Map<List<T.LicenseDetail>>(request.LicenseDetails);
            var createdResponse = new CreateLicenseResponse();
            createdResponse.MessageList = new();


            if (request.LicenseStatus == LicenseStatusEnum.BaseLicense)
            {
                var licenseType = _licenseTypeReadRepository.GetWhere(lt => lt.Id == Guid.Parse(request.LicenseTypeId)).FirstOrDefault();

                T.License license = new();
                license.CompanyId = Guid.Parse(request.CompanyId);
                license.GModuleId = Guid.Parse(request.GModuleId);
                license.LicenseTypeId = Guid.Parse(request.LicenseTypeId);
                license.LicenseKey = Guid.NewGuid();
                license.StartDate = request.StartDate;
                license.ExpirationDate = license.StartDate.AddMonths(licenseType.UsageMounth);
                license.TotalUserNumber = request.TotalUserNumber;
                license.TotalCompanyNumber = request.TotalCompanyNumber;

                license = await _licenseWriteRepository.AddAsync(license);


                foreach (var item in licenseDetails)
                {
                    item.LicenseId = license.Id;
                }

                createdResponse.License = _mapper.Map<CreateLicenseResponseVM>(license);

                createdResponse.MessageList.Add("License Added Success");
            }
            else if (request.LicenseStatus == LicenseStatusEnum.ExtraLicense)
            {
                if (lastLicense != null)
                {
                    foreach (var item in licenseDetails)
                    {
                        item.LicenseId = lastLicense.Id;
                    }

                    lastLicense.TotalUserNumber = request.TotalUserNumber;
                    lastLicense.TotalCompanyNumber = request.TotalCompanyNumber;

                    createdResponse.MessageList.Add("Last License User/Company number updated success");
                }
                else
                {
                    throw new Exception("License was not found!");
                }
            }
            else
            {
                throw new Exception("License status is not valid.");
            }

            await _licenseWriteRepository.SaveAsync();
            await _licenseDetailWriteRepository.AddRangeAsync(licenseDetails);
            await _licenseDetailWriteRepository.SaveAsync();
            createdResponse.MessageList.Add("License Detail Added Success");

            return createdResponse;
        }
    }
}