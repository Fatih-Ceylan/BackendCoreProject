using BaseProject.Domain.Entities.GCrm.Enums;
using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Opportunity.Update
{
    public class UpdateOpportunityRequest : IRequest<UpdateOpportunityResponse>
    {
        public string? CompanyId { get; set; }
        public string? Id { get; set; }
        //public string EmployeeId { get; set; }
        public string?  SalesUserId { get; set; } //satıs elemanını cekmek ıcın
        public string? OpportunitySectorId { get; set; }
        public string? TenderCustomerId { get; set; } //ihaleye cıkan kuruluş şirket
        public string? OfferCustomerId { get; set; } //teklif verilecek firma
        public string? OpportunityStageId { get; set; } //aşama
        //public int SolutionOfferId { get; set; }
        public string? SolutionOffer { get; set; } //sunulacak çözumler elle gırılmesı ıstendı
        public string? OpportunityReferenceId { get; set; }
        //public string CompanyContactNameId { get; set; }
        public string? OfferCustomerContactId { get; set; }
        public DateTime? TenderBroadcastDate { get; set; }
        public DateTime? SpecificationDate { get; set; }
        public DateTime? FinalOfferDate { get; set; }
        public string? OpportunitySubject { get; set; }
        public int? RemainingTime { get; set; }
        public string? BrandsOffered { get; set; }
        public string? ReferrerPerson { get; set; }
        public decimal? OpportunityTotalAmount { get; set; }
        public decimal? PotentialAmount { get; set; }
        //public OpportunityStageEnum? OpportunityStageEnum { get; set; } // aşama
        public OpportunityStatuEnum? OpportunityStatu { get; set; }
        public int? ProbabilityWinning { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public string? OpportunityLocation { get; set; }
        public string?  ActionTaken { get; set; }
        public CurrencyTypeEnum? OpportunityTotalAmountEnum { get; set; } //para birimi türü 
        
        public CurrencyTypeEnum? PotentialAmountEnum { get; set; } //para birimi türüv
       
    }
}
