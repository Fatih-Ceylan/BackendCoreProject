using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Domain.Entities.GCrm.Enums;
using BaseProject.Domain.Entities.Identity;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity
{
    public class Opportunity : BaseEntity
    {
        public Guid? CompanyId { get; set; }
        public string? SalesUserId { get; set; } //satıs elemanını cekmek ıcın
        public string OpportunitySubject { get; set; } //fırsat konusu
        public Guid OpportunitySectorId { get; set; } //sektör
        public Guid TenderCustomerId { get; set; } //ihaleye cıkan kuruluş şirket    
        public Guid OfferCustomerId { get; set; } //teklif verilecek firma 
        public Guid OfferCustomerContactId { get; set; }
        public Guid OpportunityStageId { get; set; } //aşama
        public DateTime? TenderBroadcastDate { get; set; } //ihale yayın tarihi
        public DateTime? SpecificationDate { get; set; } //şartname alma tarihi
        public DateTime? FinalOfferDate { get; set; } //son teklıf verme tarıhı
        public int? RemainingTime { get; set; } // kalan süre gün
        public string SolutionOffer { get; set; } //sunulacak çözumler elle gırılmesı ıstendı
        public string? BrandsOffered { get; set; } // sunulan markalar   
        public Guid? OpportunityReferenceId { get; set; } // referans   
        public string? ReferrerPerson { get; set; } // yönlendiren kişi
        public decimal? OpportunityTotalAmount { get; set; } // fırsat toplam tutar
        public CurrencyTypeEnum? OpportunityTotalAmountEnum { get; set; } //para birimi türü 
        public decimal? PotentialAmount { get; set; } // potansiyel tutar
        public CurrencyTypeEnum? PotentialAmountEnum { get; set; } //para birimi türü
        public OpportunityStatuEnum? OpportunityStatu { get; set; } // durum
        public int? ProbabilityWinning { get; set; } //kazanılma olasılığı
        public DateTime? EstimatedEndDate { get; set; } //tahmını bıtıs tarıhı
        public string? OpportunityLocation { get; set; } // fırsat konumu
        public string? ActionTaken { get; set; } // alınacak aksiyon              
        public OpportunitySector OpportunitySector { get; set; }
        public OpportunityStage OpportunityStage { get; set; }
        public Company? Company { get; set; }
        public Customer TenderCustomer { get; set; } //customerdan gelecek
        public Customer OfferCustomer { get; set; } //customerdan gelecek
        public OpportunityReference OpportunityReference { get; set; }
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
        public AppUser? SalesUser { get; set; }

    }
}
