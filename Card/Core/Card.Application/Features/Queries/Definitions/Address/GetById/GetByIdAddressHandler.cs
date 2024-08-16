using BaseProject.Application.Repositories.ReadRepository.Definitions;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Address.GetById
{
    public class GetByIdAddressHandler : IRequestHandler<GetByIdAddressRequest, GetByIdAddressResponse>
    {
        readonly IAddressReadRepository _addressReadRepository;
        readonly IDistrictReadRepository _districtReadRepository;

        public GetByIdAddressHandler(IAddressReadRepository addressReadRepository, IDistrictReadRepository districtReadRepository)
        {
            _addressReadRepository = addressReadRepository;
            _districtReadRepository = districtReadRepository;
        }

        public async Task<GetByIdAddressResponse> Handle(GetByIdAddressRequest request, CancellationToken cancellationToken)
        { 

            var address = _addressReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id))
                            .Select(c => new AddressVM
                            {
                                Id = c.Id.ToString(),
                                CreatedDate = c.CreatedDate,
                                AddressLine = c.AddressLine,
                                AddressType = c.AddressType,
                                BranchId=c.BranchId.ToString(), 
                                BranchName = c.Branch.Name, 
                                CompanyName = c.Branch.Company.Name,
                                CompanyId=c.CompanyId.ToString(),
                                CityId=c.CityId.ToString(),
                                CountryId=c.CountryId.ToString(),
                                DistrictId=c.DistrictId.ToString(),
                            }).FirstOrDefault();

            var locationNames = _districtReadRepository.GetWhere(d => d.Idc == int.Parse(address.DistrictId)).Select(d => new AddressVM
            {
                CityName = d.City.Name,
                DistrictName = d.Name,
                CountryName = d.City.Country.Name

            }).FirstOrDefault();

            address.CityName = locationNames.CityName;
            address.DistrictName = locationNames.DistrictName;
            address.CountryName = locationNames.CountryName;

            return new()
            {
                Address = address
            };
        }
    }
}
