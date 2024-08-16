using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Customer.GetById
{
    public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerRequest, GetByIdCustomerResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetByIdCustomerHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<GetByIdCustomerResponse> Handle(GetByIdCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _customerReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)

                            .Select(c => new CustomerGetByIdVM
                            {
                                Id = c.Id.ToString(),
                                Code = c.Code,
                                CustomerGroupId = c.CustomerGroupId.ToString(),
                                CustomerGroupName = c.CustomerGroup != null ? c.CustomerGroup.CustomerGroupName : null,
                                Name = c.Name,
                                DefaultContactId = c.DefaultContactId.ToString(),
                                DefaultContactName = c.CustomerContacts != null ? c.CustomerContacts.Where(cc => cc.Id == c.DefaultContactId).Select(cc => cc.Name).FirstOrDefault() : null,
                                DefaultContactTitle = c.CustomerContacts != null ? c.CustomerContacts.Where(cc => cc.Id == c.DefaultContactId).Select(cc => cc.Title).FirstOrDefault() : null,
                                DefaultDepartmentName = c.CustomerContacts != null ? c.CustomerContacts.Where(cc => cc.Id == c.DefaultContactId).Select(cc => cc.Department).FirstOrDefault() : null,
                                DefaultContactPhone = c.CustomerContacts != null ? c.CustomerContacts.Where(cc => cc.Id == c.DefaultContactId).Select(cc => cc.Phone).FirstOrDefault() : null,
                                DefaultContactEmail = c.CustomerContacts != null ? c.CustomerContacts.Where(cc => cc.Id == c.DefaultContactId).Select(cc => cc.Email1).FirstOrDefault() : null,
                                CustomerStatusId = c.CustomerStatusId.ToString(),
                                CustomerStatusName = c.CustomerStatus.Name,
                                CustomerKindId = c.CustomerKindId.ToString(),
                                CustomerKindName = c.CustomerKind != null ? c.CustomerKind.Name : null,
                                CustomerTypeId = c.CustomerTypeId.ToString(),
                                CustomerTypeName = c.CustomerType != null ? c.CustomerType.Name : null,
                                CustomerSectorId = c.CustomerSectorId.ToString(),
                                CustomerSectorName = c.CustomerSector.Name,
                                CustomerSourceId = c.CustomerSourceId.ToString(),
                                CustomerSourceName = c.CustomerSource.Name,
                                CustomerCategory = c.CustomerCategories.Select(c => new CustomerCategoryVM
                                {
                                    Id = c.Id.ToString(),
                                    Name = c.Name,
                                }).ToList(),

                                CustomerContacts = c.CustomerContacts
                                    .Where(cc => cc != null) // null olmayan öğeleri filtrele
                                    .Select(cc => new CustomerContactListVM
                                    {
                                        Id = cc.Id.ToString(),
                                        Name = cc.Name,
                                        CustomerName = cc.Customer.Name,
                                        Title = cc.Title,
                                        Department = cc.Department,
                                        Email1 = cc.Email1,
                                        Phone = cc.Phone

                                    }).ToList(),


                                CustomerAddress = c.CustomerAddresses.Select(c => new CustomerAddressGetByIdVM
                                {
                                    Id = c.Id.ToString(),
                                    AddressType = c.AddressType,
                                    Address1 = c.Address1,
                                    Address2 = c.Address2,
                                    CountryId = c.CountryId,
                                    CityId = c.CityId,
                                    DistrictId = c.DistrictId,
                                    PostalCode = c.PostalCode,
                                    CountryCode = c.CountryCode,
                                    RegionCode = c.RegionCode,
                                    //Phone = c.Phone,
                                    //Phone2 = c.Phone2,
                                    //FaxNo = c.FaxNo,
                                    //Mobile = c.Mobile,
                                    //Email1 = c.Email1,
                                    //Email2 = c.Email2,
                                    //WebAddress = c.WebAddress,

                                }).ToList(),

                                IsActive = c.IsActive,
                                CustomerRepresentativeId = c.CustomerRepresentativeId.ToString(),
                                CustomerRepresentativeName = c.CustomerRepresentative.FullName,
                                Description = c.Description,
                                TrackStatus = c.TrackStatus,
                                TaxOffice = c.TaxOffice,
                                TaxNo = c.TaxNo,
                                CurrencyType = c.CurrencyType.Value,
                                PaymentType = c.PaymentType.Value,
                                PaymentMethod = c.PaymentMethod,
                                RiskStatus = c.RiskStatus.Value,
                                SkypeAddress = c.SkypeAddress,
                                LinkedinAddress = c.LinkedinAddress,
                                FacebookAddress = c.FacebookAddress,
                                TwitterAddress = c.TwitterAddress,
                                CustomerRating = c.CustomerRating,
                                CreatedDate = c.CreatedDate,
                                Phone = c.Phone,
                                Phone2 = c.Phone2,
                                FaxNo = c.FaxNo,
                                Mobile = c.Mobile,
                                Email1 = c.Email1,
                                Email2 = c.Email2,
                                WebAddress = c.WebAddress,
                                CompanyId = c.CompanyId.ToString()
                            }).FirstOrDefault();
            return new()
            {
                Customer = customer
            };
        }
    }
}