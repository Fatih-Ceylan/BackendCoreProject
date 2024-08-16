using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivity.GetAll
{
    public class GetAllCustomerActivityHandler : IRequestHandler<GetAllCustomerActivityRequest, GetAllCustomerActivityResponse>
    {
        readonly ICustomerActivityReadRepository _customerActivityReadRepository;
        readonly ICustomerReadRepository _customerReadRepository;

        public GetAllCustomerActivityHandler(ICustomerActivityReadRepository customerActivityReadRepository, ICustomerReadRepository customerReadRepository)
        {
            _customerActivityReadRepository = customerActivityReadRepository;
            _customerReadRepository = customerReadRepository;
        }
        public Task<GetAllCustomerActivityResponse> Handle(GetAllCustomerActivityRequest request, CancellationToken cancellationToken)
        {
            var query = _customerActivityReadRepository.GetAllDeletedStatusDesc(false)
            .Include(cat => cat.CustomerActivityTeams).Select(ca => new CustomerActivityVM
            {
                Id = ca.Id,
                ActivityAddress = ca.ActivityAddress,
                ActivityDescription = ca.ActivityDescription,
                ActivityDate = ca.ActivityDate,
                ReminderDate = ca.ReminderDate,
                OfferCode = ca.OfferCode,
                ProjectCode = ca.ProjectCode,
                OpportunityCode = ca.OpportunityCode,
                EmailStatus = ca.EmailStatus,
                CustomerId = ca.CustomerId.ToString(),
                CustomerName = ca.Customer.Name,
                CustomerActivityKindId = ca.CustomerActivityKindId.ToString(),
                CustomerActivityKindName = ca.CustomerActivityKind != null ? ca.CustomerActivityKind.Name : null,
                CustomerContactId = ca.CustomerContactId.ToString(),
                CustomerActivityTypeId = ca.CustomerActivityTypeId.ToString(),
                CustomerActivityTypeName = ca.CustomerActivityType != null ? ca.CustomerActivityType.Name : null,
                CustomerActivitySubjectId = ca.CustomerActivitySubjectId.ToString(),
                CustomerActivitySubjectName = ca.CustomerActivitySubject != null ? ca.CustomerActivitySubject.Name : null,
                CustomerActivityStatusId = ca.CustomerActivityStatusId.ToString(),
                CustomerActivityStatusName = ca.CustomerActivityStatus != null ? ca.CustomerActivityStatus.Name : null,
                Code = ca.Code,
                CustomerActivityTeams = ca.CustomerActivityTeams.Select(c => new CustomerActivityTeamVM
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                }).ToList(),


                CustomerCategories = ca.Customer.CustomerCategories != null ? ca.Customer.CustomerCategories.Select(c => new CustomerCategoryVM
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                }).ToList() : null,

                //CustomerCityId = ca.Customer.CustomerAddresses != null ? ca.Customer.CustomerAddresses.FirstOrDefault().CityId : null,
                CustomerCityName = ca.Customer.CustomerAddresses != null ? ca.Customer.CustomerAddresses.FirstOrDefault().District.City.Name : null,
                CustomerDistrictName = ca.Customer.CustomerAddresses != null ? ca.Customer.CustomerAddresses.FirstOrDefault().District.Name : null,
                CustomerContactMail = ca.CustomerContact.Email1,
                CustomerContactName = ca.CustomerContact.Name,
                CustomerContactPhone = ca.CustomerContact.Phone,
                CustomerGroupId = ca.Customer.CustomerGroupId.ToString(),
                CustomerGroupName = ca.Customer.CustomerGroup.CustomerGroupName,
                CustomerMail = ca.Customer.Email1,
                CustomerPhone = ca.Customer.Phone,
                CustomerSectorId = ca.Customer.CustomerSectorId.ToString(),
                CustomerSectorName = ca.Customer.CustomerSector.Name,
                CustomerStatusName = ca.Customer.CustomerStatus.Name,
                CustomerContactTitleName = ca.Customer.CustomerContacts.FirstOrDefault().Title,
                //BranchId = ca.BranchId.ToString(),
                CompanyId = ca.CompanyId.ToString(),
                CreatedBy = ca.CreatedBy.ToString(),
                UpdatedDate = ca.UpdatedDate,
                CreatedDate = ca.CreatedDate,
            });

            //var customer = _customerReadRepository.GetByIdAsyncIncluding([e => e.CustomerCategories], query.First().CustomerId).Result;

            var totalCount = query.Count();
            if (!string.IsNullOrEmpty(request.CompanyId) && request.CompanyId != "SelectAll")
            {
                query = query.Where(b => b.CompanyId == request.CompanyId);
                totalCount = query.Count();
            }

            var customerActivities = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                 .Take(request.Size).ToList()
                                          : query.ToList();

            return Task.FromResult(new GetAllCustomerActivityResponse
            {
                TotalCount = totalCount,
                CustomerActivities = customerActivities,
            });
        }
    }
}
