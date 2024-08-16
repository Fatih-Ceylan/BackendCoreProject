using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Customer.GetAll
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerRequest, GetAllCustomerResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;

        public GetAllCustomerHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public Task<GetAllCustomerResponse> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
        {
            //contakt
            var query = _customerReadRepository.GetAllDeletedStatusDesc(false)
                .Select(c => new CustomerVM
                {
                    Id = c.Id.ToString(),
                    Code = c.Code != null ? c.Code : null,

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
                    UpdatedDate = c.UpdatedDate,
                    FilePath = c.FilePath,
                    CustomerCategories = c.CustomerCategories.Select(c => new CustomerCategoryVM
                    {
                        Id = c.Id.ToString(),
                        Name = c.Name,
                    }).ToList(),
                    IsActive = c.IsActive,

                    CustomerContacts = c.CustomerContacts.Select(cc => new CustomerContactVM
                    {
                        Id = cc.Id.ToString(),
                        Name = cc.Name,
                        CustomerId = cc.CustomerId.ToString(),
                        CustomerName = cc.Customer.Name,
                        Title = cc.Title,
                        Department = cc.Department,
                        Phone = cc.Phone,
                        InternalNo = cc.InternalNo,
                        Mobile = cc.Mobile,
                        Email1 = cc.Email1,
                        Email2 = cc.Email2,
                        FaxNo = cc.FaxNo,
                        Description = cc.Description,
                        //AddressType = cc.AddressType.ToString(),
                        DecisionStatus = cc.DecisionStatus,
                        RelationCompany = cc.RelationCompany,
                        Status = cc.Status,
                        Gender = cc.Gender,
                        BirthDate = cc.BirthDate,
                        MaritalStatus = cc.MaritalStatus,
                        //MarriageDate = cc.MarriageDate,
                        AssistantName = cc.AssistantName,
                        AssistantPhone = cc.AssistantPhone,
                        CardVisitImagePath = cc.CardVisitImagePath
                    }

                    ).ToList(),

                    CustomerAddress = c.CustomerAddresses.Select(cc => new CustomerAddressVM
                    {
                        AddressType = cc.AddressType,
                        Address1 = cc.Address1,
                        Address2 = cc.Address2,
                        CountryId = cc.CountryId,
                        CountryName = c.CustomerAddresses != null ? c.CustomerAddresses.Where(cc => cc.CountryId == c.CustomerAddresses.FirstOrDefault().District.City.CountryId).Select(cc => cc.District.City.Country.Name).FirstOrDefault() : null,
                        CityId = cc.CityId,
                        CityName = c.CustomerAddresses != null ? c.CustomerAddresses.Where(cc => cc.CityId == c.CustomerAddresses.FirstOrDefault().District.City.Idc).Select(cc => cc.District.City.Name).FirstOrDefault() : null,
                        DistrictId = cc.DistrictId,
                        DistrictName = c.CustomerAddresses != null ? c.CustomerAddresses.Where(cc => cc.DistrictId == c.CustomerAddresses.FirstOrDefault().District.Idc).Select(cc => cc.District.Name).FirstOrDefault() : null,
                        PostalCode = cc.PostalCode,
                        CountryCode = cc.CountryCode,
                        RegionCode = cc.RegionCode,
                        Id=cc.Id.ToString(),
                        CreatedDate = cc.CreatedDate,
                        CustomerId=cc.CustomerId.ToString(),
                        CustomerName=cc.Customer.Name,
                        
                   
                    }).ToList(),
                    CustomerRepresentativeId = c.CustomerRepresentativeId.ToString(),
                    CustomerRepresentativeName = c.CustomerRepresentative.FullName,
                    Description = c.Description,
                    TrackStatus = c.TrackStatus,
                    TaxOffice = c.TaxOffice,
                    TaxNo = c.TaxNo,
                    PaymentType = c.PaymentType.Value,
                    CurrencyType = c.CurrencyType.Value,
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
                    CompanyId = c.CompanyId.ToString(),
                });

            var totalCount = query.Count();
            if (!string.IsNullOrEmpty(request.CompanyId) && request.CompanyId != "SelectAll")
            {
                query = query.Where(b => b.CompanyId == request.CompanyId);
                totalCount = query.Count();
            }
            var customers = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                  .Take(request.Size).ToList()
                                                  : query.ToList();

            return Task.FromResult(new GetAllCustomerResponse
            {
                TotalCount = totalCount,
                Customers = customers,
            });
        }
    }
}