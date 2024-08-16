using GCrm.Domain.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.OpportunityManagement
{
    public class Opportunity : BaseEntity
    {      
        public int OpportunitySectorId { get; set; }
        public int CompanyTenderId { get; set; }
        public int CompanyOfferId { get; set; }
        public int SolutionOfferId { get; set; }
        public int ReferenceId { get; set; }
        public int StageId { get; set; }
        public int CompanyContactNameId { get; set; }
        public DateTime TenderBroadcastDate { get; set; }
        public DateTime SpecificationDate { get; set; }
        public DateTime FinalOfferDate { get; set; }
        public string OpportunitySubject { get; set; }
        public int RemainingTime { get; set; }    
        public string BrandsOffered { get; set; }     
        public string ReferrerPerson { get; set; }
        public int OpportunityTotalAmount { get; set; }
        public int PotentialAmount { get; set; }    
        public OpportunityStatuEnum OpportunityStatu { get; set; }
        public int ProbabilityWinning { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public int OpportunityLocation { get; set; }
        public int ActionTaken { get; set; }
        public CurrencyTypeEnum CurrencyTypeEnum { get; set; }    
        public OpportunitySector OpportunitySector { get; set; }
        public CompanyTender CompanyTender { get; set; }
        public CompanyOffer CompanyOffer { get; set; }
        public CompanyContactName CompanyContactName { get; set; }
        public SolutionOffer SolutionOffer { get; set; }
       

    }
}
