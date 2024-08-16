using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.SpecialOffer;

namespace Platform.Application.Features.Queries.Definitions.SpecialOffer.GetAll
{
    public class GetAllSpecialOfferHandler : IRequestHandler<GetAllSpecialOfferRequest, GetAllSpecialOfferResponse>
    {
        readonly ISpecialOfferReadRepository _specialOfferReadRepository;

        public GetAllSpecialOfferHandler(ISpecialOfferReadRepository specialOfferReadRepository)
        {
            _specialOfferReadRepository = specialOfferReadRepository;
        }

        public async Task<GetAllSpecialOfferResponse> Handle(GetAllSpecialOfferRequest request, CancellationToken cancellationToken)
        {
            var query = _specialOfferReadRepository
                         .GetAllDeletedStatusDesc(false, request.IsDeleted)
                         .Select(so => new SpecialOfferVM
                         {
                             Id = so.Id.ToString(),
                             CompanyId = so.CompanyId.ToString(),
                             CompanyName = so.Company.Name,
                             CreatedDate = so.CreatedDate,
                             DiscountRate = so.DiscountRate,
                             EndDate = so.EndDate,
                             GModuleId = so.GModuleId.ToString(),
                             GModuleName = so.GModule.Name,
                             StartDate = so.StartDate,
                             Description = so.Description,
                         });
            var totalCount = query.Count();
            var specialOffers = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                            .Take(request.Size).ToList()
                                                     : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                SpecialOffers = specialOffers,
            };
        }
    }
}