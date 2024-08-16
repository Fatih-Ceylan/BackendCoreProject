using BaseProject.Domain.Entities.GCrm.Enums;
using Utilities.Core.UtilityApplication.VMs;

namespace GCrm.Application.VMs.Definitions
{
    public class OpportunityVM : BaseVM
    {
        public string OpportunitySectorId { get; set; }
        public string OpportunitySectorName { get; set; }
        public string TenderCustomerId { get; set; } //ihaleye cıkan kuruluş şirket
        public string TenderCustomerName { get; set; } //ihaleye cıkan kuruluş şirket adı
        public string OfferCustomerId { get; set; } //teklif verilecek firma
        public string OfferCustomerName { get; set; } //teklif verilecek firma adı 
        public string SalesUserId { get; set; } //satıs elemanını cekmek ıcın
        public string SalesUserName { get; set; } //satıs elemanını cekmek ıcın
        public string SolutionOffer { get; set; } //sunulacak çözumler elle gırılmesı ıstendı
        public string OpportunityReferenceId { get; set; }
        public string OpportunityReferenceName { get; set; }
        //public string StageId { get; set; }
        public string OpportunityStageId { get; set; } //aşama
        public string OpportunityStageName { get; set; } //aşama adı
        //public string CompanyContactNameId { get; set; }
        public string OfferCustomerContactId { get; set; }
        public string OfferCustomerContactName { get; set; }
        public DateTime? TenderBroadcastDate { get; set; }
        public DateTime? SpecificationDate { get; set; }
        public DateTime? FinalOfferDate { get; set; }
        public string OpportunitySubject { get; set; }
        public int RemainingTime { get; set; }
        public string BrandsOffered { get; set; }
        public string ReferrerPerson { get; set; }
        public decimal OpportunityTotalAmount { get; set; }
        public decimal PotentialAmount { get; set; }
        public OpportunityStatuEnum OpportunityStatu { get; set; }
        public int ProbabilityWinning { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public string OpportunityLocation { get; set; }
        public string ActionTaken { get; set; } // alınacak aksiyon        
        public CurrencyTypeEnum? OpportunityTotalAmountEnum { get; set; } //para birimi türü 
        public CurrencyTypeEnum? PotentialAmountEnum { get; set; } //para birimi türü
        public string? CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
