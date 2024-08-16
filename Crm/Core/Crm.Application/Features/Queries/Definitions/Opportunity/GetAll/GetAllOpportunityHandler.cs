using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Opportunity.GetAll
{
    public class GetAllOpportunityHandler : IRequestHandler<GetAllOpportunityRequest, GetAllOpportunityResponse>
    {
        readonly IOpportunityReadRepository _opportunityReadRepository;
        public GetAllOpportunityHandler(IOpportunityReadRepository opportunityReadRepository)
        {
            _opportunityReadRepository = opportunityReadRepository;
        }

        public async Task<GetAllOpportunityResponse> Handle(GetAllOpportunityRequest request, CancellationToken cancellationToken)
        {
            var opportunities = _opportunityReadRepository.GetAllDeletedStatusDesc(false)
                .Select(op => new OpportunityVM
               {
                   Id = op.Id.ToString(),
                   OpportunitySectorId = op.OpportunitySectorId.ToString(),
                   OpportunitySectorName = op.OpportunitySector != null ? op.OpportunitySector.Name : null,
                   TenderCustomerId = op.TenderCustomerId.ToString(),
                   TenderCustomerName = op.TenderCustomer.Name,
                   OfferCustomerId = op.OfferCustomerId.ToString(),
                   OfferCustomerName = op.OfferCustomer.Name,
                   SalesUserId = op.SalesUserId.ToString(),
                   SalesUserName = op.SalesUser.FullName,
                   SolutionOffer = op.SolutionOffer,
                   OpportunityReferenceId = op.OpportunityReferenceId.ToString(),
                   OpportunityReferenceName = op.OpportunityReference != null ? op.OpportunityReference.Name : null,
                   OpportunityStageId = op.OpportunityStageId.ToString(),
                   OpportunityStageName = op.OpportunityStage!= null ? op.OpportunityStage.Name : null,
                   OfferCustomerContactId = op.OfferCustomerContactId.ToString(),
                   OfferCustomerContactName = op.OfferCustomer.CustomerContacts.Where(x => x.Id == op.OfferCustomerContactId).FirstOrDefault().Name,
                   TenderBroadcastDate = op.TenderBroadcastDate,
                   SpecificationDate = op.SpecificationDate,
                   FinalOfferDate = op.FinalOfferDate,
                   OpportunitySubject = op.OpportunitySubject,
                   RemainingTime = op.RemainingTime.Value,
                   BrandsOffered = op.BrandsOffered,
                   ReferrerPerson = op.ReferrerPerson,
                   OpportunityTotalAmount = op.OpportunityTotalAmount.Value,
                   PotentialAmount = op.PotentialAmount.Value,
                   OpportunityStatu = op.OpportunityStatu.Value,
                   ProbabilityWinning = op.ProbabilityWinning.Value,
                   EstimatedEndDate = op.EstimatedEndDate.Value,
                   OpportunityLocation = op.OpportunityLocation,
                   ActionTaken = op.ActionTaken,
                   OpportunityTotalAmountEnum = op.OpportunityTotalAmountEnum,
                   PotentialAmountEnum = op.PotentialAmountEnum,
                   CompanyId = op.CompanyId.ToString(),
                   CompanyName = op.Company.Name,
               });

            var totalCount = opportunities.Count();
            var opportunityQuery = opportunities.Skip(request.Page * request.Size)
                                        .Take(request.Size)
                                        .ToList();

            return await Task.FromResult(new GetAllOpportunityResponse
            {
                TotalCount = totalCount,
                Opportunities = opportunityQuery,
            });
        }
    }
}
