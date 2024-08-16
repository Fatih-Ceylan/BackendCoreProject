using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivity.Update
{
    public class UpdateCustomerActivityRequest : IRequest<UpdateCustomerActivityResponse>
    {
        public string Id { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerContactId { get; set; }
        public string? CustomerActivitySubjectId { get; set; }
        public string? CustomerActivityTypeId { get; set; }
        public string? CustomerActivityKindId { get; set; }
        public string? CustomerActivityStatusId { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool? EmailStatus { get; set; }
        public string? ActivityAddress { get; set; }
        public string? OfferCode { get; set; } //teklif kodu şimdilik tablodan almayacak verıyı
        public string? ProjectCode { get; set; } // proje kodu şimdilik tablodan almayacak verıyı
        public string? OpportunityCode { get; set; } // fırsat kodu şimdilik tablodan almayacak verıyı
        public string? ActivityDescription { get; set; }
        public List<CustomerActivityTeamVM>? CustomerActivityTeams { get; set; }
        public string? CompanyId { get; set; }
    }
}
