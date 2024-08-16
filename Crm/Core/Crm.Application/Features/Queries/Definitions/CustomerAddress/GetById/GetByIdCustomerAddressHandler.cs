using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerAddress.GetById
{
    public class GetByIdCustomerAddressHandler : IRequestHandler<GetByIdCustomerAddressRequest, GetByIdCustomerAddressResponse>
    {
        readonly ICustomerAddressReadRepository _customerAddressReadRepository;

        public GetByIdCustomerAddressHandler(ICustomerAddressReadRepository customerAddressReadRepository)
        {
            _customerAddressReadRepository = customerAddressReadRepository;
        }

        public async Task<GetByIdCustomerAddressResponse> Handle(GetByIdCustomerAddressRequest request, CancellationToken cancellationToken)
        {
            var customerAddress = _customerAddressReadRepository
                         .GetWhere(ca => ca.Id == Guid.Parse(request.Id), false)
                         .Select(ca => new CustomerAddressVM
                         {
                             Id = ca.Id.ToString(),
                             CustomerId = ca.CustomerId.ToString(),
                             CustomerName = ca.Customer.Name,
                             AddressType = ca.AddressType,
                             Address1 = ca.Address1,
                             Address2 = ca.Address2,
                             CountryId = ca.CountryId,
                             CountryName = ca.District.City.Country.Name,
                             CityId = ca.CityId,
                             CityName = ca.District.City.Name,
                             DistrictId = ca.DistrictId,
                             DistrictName = ca.District.Name,
                             PostalCode = ca.PostalCode,
                             CountryCode = ca.CountryCode,
                             RegionCode = ca.RegionCode,
                             //Phone = ca.Phone,
                             //Phone2 = ca.Phone2,
                             //FaxNo = ca.FaxNo,
                             //Mobile = ca.Mobile,
                             //Email1 = ca.Email1,
                             //Email2 = ca.Email2,
                             //WebAddress = ca.WebAddress,
                             CreatedDate = ca.CreatedDate,
                         }).FirstOrDefault();

            return new()
            {
                CustomerAddress = customerAddress
            };
        }
    }
}