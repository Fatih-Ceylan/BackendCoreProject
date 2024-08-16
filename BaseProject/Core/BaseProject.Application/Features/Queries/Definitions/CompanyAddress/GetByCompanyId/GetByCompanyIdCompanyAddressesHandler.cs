using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.CompanyAddress;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetByCompanyId
{
    public class GetByCompanyIdCompanyAddressesHandler : IRequestHandler<GetByCompanyIdCompanyAddressesRequest, GetByCompanyIdCompanyAddressesResponse>
    {
        readonly ICompanyAddressReadRepository _companyAddressReadRepository;

        public GetByCompanyIdCompanyAddressesHandler(ICompanyAddressReadRepository companyAddressReadRepository)
        {
            _companyAddressReadRepository = companyAddressReadRepository;
        }

        public async Task<GetByCompanyIdCompanyAddressesResponse> Handle(GetByCompanyIdCompanyAddressesRequest request, CancellationToken cancellationToken)
        {
            var query = _companyAddressReadRepository
                        .GetAllDeletedStatus(false)
                        .Where(ca => ca.CompanyId == Guid.Parse(request.CompanyId))
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
                        });

            return new()
            {
                CompanyAddresses = query.ToList(),
            };
        }
    }
}