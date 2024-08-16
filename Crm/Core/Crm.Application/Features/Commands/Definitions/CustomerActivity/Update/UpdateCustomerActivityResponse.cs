using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivity.Update
{
    public class UpdateCustomerActivityResponse
    {
        public string Id { get; set; }
        public string ActivityAddress { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerContactId { get; set; }
        public string CustomerSubjectId { get; set; }
        public string CustomerActivityKindId { get; set; }
        public string CustomerActivityTypeId { get; set; }
        public string CustomerActivityStatusId { get; set; }
        public string CustomerOfferId { get; set; }
        public string CustomerProjectId { get; set; }
        public string OpportunityId { get; set; }
        public ICollection<CustomerActivityTeamVM> CustomerActivityTeams { get; set; }
        public string CompanyId { get; set; }
        public string Message { get; set; }
    }
}
