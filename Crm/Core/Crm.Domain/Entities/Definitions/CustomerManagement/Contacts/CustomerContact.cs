﻿using GCrm.Domain.Entities.Definitions.ActivitiesManagement.Activities;
using GCrm.Domain.Entities.Definitions.CustomerManagement.Customers;
using GCrm.Domain.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Contacts
{ 
    public class CustomerContact : BaseEntity
    {
        public string Name { get; set; }

        public Guid? CustomerId { get; set; }

        public string Title { get; set; }

        public string Department { get; set; }

        public string? Phone { get; set; }

        public string? InternalNo { get; set; }

        public string Mobile { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        public string? FaxNo { get; set; }

        public string? Description { get; set; }

        public AddressTypeEnum? AddressType { get; set; }

        public DecisionStatusEnum DecisionStatus { get; set; } //karar verme durumu

        public RelationCompanyEnum? RelationCompany { get; set; }//şirketle ilişkisi

        public bool Status { get; set; } //kontak durumu

        public GenderEnum? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public MaritalStatusEnum? MaritalStatus { get; set; }

        public DateTime? MarriageDate { get; set; }

        public string? AssistantName { get; set; }

        public string? AssistantPhone { get; set; }

        public string? CardVisitImagePath { get; set; }

        public Customer Customer { get; set; }

       public ICollection<CustomerActivity> CustomerActivities { get; set; }

    }
}