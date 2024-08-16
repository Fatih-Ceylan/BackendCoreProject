using GCrm.Domain.Entities.Definitions.UserManagement.Users;
using GCrm.Domain.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.OpportunityManagement.Opportunity
{
    public class Opportunity : BaseEntity
    {
        //public Guid UsersId { get; set; } //satıs elemanını cekmek ıcın
        public string OpportunitySubject { get; set; } //fırsat konusu
        public Guid OpportunitySectorId { get; set; } //sektör
        public Guid CompanyTenderId { get; set; } //ihaleye cıkan kuruluş şirket
        public Guid CompanyOfferId { get; set; } //teklif verilecek firma
        public Guid CompanyContactNameId { get; set; } //firma kontakt adı
        public DateTime? TenderBroadcastDate { get; set; } //ihale yayın tarihi
        public DateTime? SpecificationDate { get; set; } //şartname alma tarihi
        public DateTime? FinalOfferDate { get; set; } //son teklıf verme tarıhı
        public int? RemainingTime { get; set; } // kalan süre gün
        public Guid SolutionOfferId { get; set; } //sunulacak çözüm
        public string? BrandsOffered { get; set; } // sunulan markalar  
        public Guid? OpportunityReferenceId { get; set; } // referans   
        public string? ReferrerPerson { get; set; } // yönlendiren kişi
        public int? OpportunityTotalAmount { get; set; } // fırsat toplam tutar
        public CurrencyTypeEnum? CurrencyTypeEnum { get; set; } //para birimi türü
        public int? PotentialAmount { get; set; } // potansiyel tutar
        public OpportunityStageEnum? OpportunityStageEnum { get; set; } // aşama
        public OpportunityStatuEnum? OpportunityStatu { get; set; } // durum
        public int? ProbabilityWinning { get; set; } //kazanılma olasılığı
        public DateTime? EstimatedEndDate { get; set; } //tahmını bıtıs tarıhı
        public int? OpportunityLocation { get; set; } // fırsat konumu
        public int? ActionTaken { get; set; } // alınacak aksiyon              
        public OpportunitySector OpportunitySector { get; set; }
        public ICollection<Users> Users  { get; set; }
        public CompanyTender CompanyTender { get; set; }
        public CompanyOffer CompanyOffer { get; set; }
        public CompanyContactName CompanyContactName { get; set; }
        public SolutionOffer SolutionOffer { get; set; }
        public OpportunityReference  OpportunityReference { get; set; }

    }
}
