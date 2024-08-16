using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerAddress.GetAll
{
    public class GetAllCustomerAddressHandler : IRequestHandler<GetAllCustomerAddressRequest, GetAllCustomerAddressResponse>
    {
        readonly ICustomerAddressReadRepository _customerAddressReadRepository;

        public GetAllCustomerAddressHandler(ICustomerAddressReadRepository customerAddressReadRepository)
        {
            _customerAddressReadRepository = customerAddressReadRepository;
        }

        public Task<GetAllCustomerAddressResponse> Handle(GetAllCustomerAddressRequest request, CancellationToken cancellationToken)
        {
            var query = _customerAddressReadRepository
                        .GetAllDeletedStatusDesc(false)
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
                        });

            var totalCount = query.Count();
            var customerAddresses = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerAddressResponse
            {
                TotalCount = totalCount,
                CustomerAddresses = customerAddresses,
            });
        }
    }
}