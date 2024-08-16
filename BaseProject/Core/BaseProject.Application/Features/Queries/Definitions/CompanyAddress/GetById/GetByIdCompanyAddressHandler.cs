using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.CompanyAddress;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetById
{
    public class GetByIdCompanyAddressHandler : IRequestHandler<GetByIdCompanyAddressRequest, GetByIdCompanyAddressResponse>
    {
        readonly ICompanyAddressReadRepository _companyAddressReadRepository;

        public GetByIdCompanyAddressHandler(ICompanyAddressReadRepository companyAddressReadRepository)
        {
            _companyAddressReadRepository = companyAddressReadRepository;
        }

        public async Task<GetByIdCompanyAddressResponse> Handle(GetByIdCompanyAddressRequest request, CancellationToken cancellationToken)
        {
            var companyAddress = _companyAddressReadRepository
                              .GetWhere(at => at.Id == Guid.Parse(request.Id))
                               .Select(ca => new CompanyAddressVM
                               {
                                   Id = ca.Id.ToString(),
                                   CreatedDate = ca.CreatedDate,
                                   CompanyId = ca.CompanyId.ToString(),
                                   CompanyName = ca.Company.Name,
                                   AddressTypeId = ca.AddressTypeId.ToString(),
                                   AddressTypeName = ca.AddressType.Name,
                                   FullAddress = ca.FullAddress,
                                   PostalCode = ca.PostalCode,
                                   CountryId = ca.CountryId,
                                   CountryName = ca.DistrictId != null ? ca.District.City.Country.Name : null,
                                   CityId = ca.CityId,
                                   CityName = ca.DistrictId != null ? ca.District.City.Name : null,
                                   DistrictId = ca.DistrictId,
                                   DistrictName = ca.DistrictId != null ? ca.District.Name : null
                               }).FirstOrDefault();

            return new()
            {
                CompanyAddress = companyAddress
            };
        }
    }
}