using BaseProject.Domain.Entities.GCrm.Enums;

namespace GCrm.Application.VMs.Definitions
{
    public class CustomerContactCreateVM
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? ContactId { get; set; }

        public string? CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public string? Title { get; set; }

        public string? Department { get; set; }

        public string? Phone { get; set; }

        public string? InternalNo { get; set; }

        public string? Mobile { get; set; }

        public string? Email1 { get; set; }

        public string? Email2 { get; set; }

        public string? FaxNo { get; set; }

        public string? Description { get; set; }

        public AddressTypeEnum? AddressType { get; set; }

        public DecisionStatusEnum? DecisionStatus { get; set; }

        public RelationCompanyEnum? RelationCompany { get; set; }
        public bool Status { get; set; }

        public GenderEnum? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public MaritalStatusEnum? MaritalStatus { get; set; }

        public DateTime? MarriageDate { get; set; }

        public string? AssistantName { get; set; }

        public string? AssistantPhone { get; set; }

        public string? CardVisitImagePath { get; set; }
    }
}
