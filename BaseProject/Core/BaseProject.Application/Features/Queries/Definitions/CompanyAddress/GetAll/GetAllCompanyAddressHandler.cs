using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.CompanyAddress;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetAll
{
    public class GetAllCompanyAddressHandler : IRequestHandler<GetAllCompanyAddressRequest, GetAllCompanyAddressResponse>
    {
        readonly ICompanyAddressReadRepository _companyAddressReadRepository;

        public GetAllCompanyAddressHandler(ICompanyAddressReadRepository companyAddressReadRepository)
        {
            _companyAddressReadRepository = companyAddressReadRepository;
        }

        public async Task<GetAllCompanyAddressResponse> Handle(GetAllCompanyAddressRequest request, CancellationToken cancellationToken)
        {
            var query = _companyAddressReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted)
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

            var totalCount = query.Count();
            var companyAddresses = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                           .Take(request.Size).ToList()
                                                     : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                CompanyAddresses = companyAddresses,
            };
        }
    }
}