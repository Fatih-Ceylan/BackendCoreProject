using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.Company;
using BaseProject.Application.VMs.Definitions.CompanyAddress;
using BaseProject.Application.VMs.Definitions.CompanyLicense;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetById
{
    public class GetByIdCompanyHandler : IRequestHandler<GetByIdCompanyRequest, GetByIdCompanyResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly ICompanyAddressReadRepository _companyAddressReadRepository;
        readonly ICompanyLicenseReadRepository _companyLicenseReadRepository;

        public GetByIdCompanyHandler(ICompanyReadRepository companyReadRepository, ICompanyAddressReadRepository companyAddressReadRepository, ICompanyLicenseReadRepository companyLicenseReadRepository)
        {
            _companyReadRepository = companyReadRepository;
            _companyAddressReadRepository = companyAddressReadRepository;
            _companyLicenseReadRepository = companyLicenseReadRepository;
        }

        public async Task<GetByIdCompanyResponse> Handle(GetByIdCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = _companyReadRepository
                          .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new CompanyVM
                           {
                               Id = c.Id.ToString(),
                               MainCompanyId = c.MainCompanyId.ToString(),
                               MainCompanyName = _companyReadRepository.GetAll(false)
                                                                       .Where(mc => mc.Id == c.MainCompanyId)
                                                                       .Select(mc => mc.Name)
                                                                       .FirstOrDefault(),
                               LogoPath = c.LogoPath,
                               Name = c.Name,
                               AuthorizedFullName = c.AuthorizedFullName,
                               PhoneNumber = c.PhoneNumber,
                               FaxNo = c.FaxNo,
                               Email = c.Email,
                               WebAddress = c.WebAddress,
                               TaxOffice = c.TaxOffice,
                               TaxNo = c.TaxNo,
                               TradeRegisterNo = c.TradeRegisterNo,
                               SocialSecurityNo = c.SocialSecurityNo,
                               MersisNo = c.MersisNo,
                               CreatedDate = c.CreatedDate,
                               CompanyLicenses = _companyLicenseReadRepository.GetAllDeletedStatusDesc(false,false)
                                                                              .Where(cl => cl.CompanyId == c.Id)
                                                                              .Select(cl => new CompanyLicenseCreateVM
                                                                              {
                                                                                  LicenseId = cl.LicenseId.ToString(),
                                                                                  IsInUse = cl.IsInUse
                                                                              })
                                                                              .ToList(),
                               CompanyAddresses = _companyAddressReadRepository.GetAllDeletedStatusDesc(false,false)
                                                                               .Where(ca => ca.CompanyId == c.Id)
                                                                               .Select(ca => new CompanyAddressVM
                                                                               {
                                                                                   Id = ca.Id.ToString(),
                                                                                   CreatedDate = ca.CreatedDate,
                                                                                   AddressTypeId = ca.AddressTypeId.ToString(),
                                                                                   AddressTypeName = ca.AddressType.Name,
                                                                                   FullAddress = ca.FullAddress,
                                                                                   PostalCode = ca.PostalCode,
                                                                                   CountryId = ca.CountryId,
                                                                                   CountryName = ca.CountryId != null ? ca.District.City.Country.Name : null,
                                                                                   CityId = ca.CityId,
                                                                                   CityName = ca.CityId != null ? ca.District.City.Name : null,
                                                                                   DistrictId = ca.DistrictId,
                                                                                   DistrictName = ca.DistrictId != null ? ca.District.Name : null
                                                                               }).ToList()
                               
                           }).FirstOrDefault();

            return new()
            {
                Company = company
            };
        }
    }
}