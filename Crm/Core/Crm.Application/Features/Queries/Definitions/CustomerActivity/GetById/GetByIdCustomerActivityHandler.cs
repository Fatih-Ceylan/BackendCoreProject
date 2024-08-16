using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivity.GetById
{
    public class GetByIdCustomerActivityHandler : IRequestHandler<GetByIdCustomerActivityRequest, GetByIdCustomerActivityResponse>
    {

        readonly ICustomerActivityReadRepository _customerActivityReadRepository;
        public GetByIdCustomerActivityHandler(ICustomerActivityReadRepository customerActivityReadRepository)
        {
            _customerActivityReadRepository = customerActivityReadRepository;
        }
        public async Task<GetByIdCustomerActivityResponse> Handle(GetByIdCustomerActivityRequest request, CancellationToken cancellationToken)
        {
            var customeractivity = _customerActivityReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Include(c => c.CustomerActivityTeams).Select(c => new CustomerActivityGetByIdVM
                           {
                               Id = c.Id.ToString(),
                               ActivityAddress = c.ActivityAddress,
                               ActivityDescription = c.ActivityDescription,
                               ActivityDate = c.ActivityDate,
                               ReminderDate = c.ReminderDate,
                               CustomerContactId = c.CustomerContactId.ToString(),
                               CustomerContactName = c.CustomerContact.Name,
                               OfferCode = c.OfferCode,
                               ProjectCode = c.ProjectCode,
                               EmailStatus = c.EmailStatus,
                               OpportunityCode = c.OpportunityCode,
                               CustomerActivitySubjectId = c.CustomerActivitySubjectId.ToString(),
                               CustomerId = c.CustomerId.ToString(),
                               CustomerName = c.Customer.Name,
                               CustomerActivityKindId = c.CustomerActivityKindId.ToString(),
                               CustomerActivityTypeId = c.CustomerActivityTypeId.ToString(),
                               CustomerActivityStatusId = c.CustomerActivityStatusId.ToString(),
                               CustomerActivityTeams = c.CustomerActivityTeams.Select(c => new CustomerActivityTeamVM
                               {
                                   Id = c.Id.ToString(),
                                   Name = c.Name,
                               }).ToList(),
                               CustomerContacts = c.Customer.CustomerContacts.Select(contact => new CustomerContactIdNameVM
                               {
                                   Id = contact.Id.ToString(),
                                   Name = contact.Name,
                               }).ToList(),
                               //BranchId = c.BranchId.ToString(),
                               CompanyId = c.CompanyId.ToString(),
                               CreatedDate = c.CreatedDate,

                           }).FirstOrDefault();
            return new()
            {
                customerActivity = customeractivity
            };
        }
    }
}
