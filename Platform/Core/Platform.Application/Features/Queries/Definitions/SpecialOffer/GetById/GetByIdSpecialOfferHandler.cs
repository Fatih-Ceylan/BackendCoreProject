using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.SpecialOffer;

namespace Platform.Application.Features.Queries.Definitions.SpecialOffer.GetById
{
    public class GetByIdSpecialOfferHandler : IRequestHandler<GetByIdSpecialOfferRequest, GetByIdSpecialOfferResponse>
    {
        readonly ISpecialOfferReadRepository _specialOfferReadRepository;

        public GetByIdSpecialOfferHandler(ISpecialOfferReadRepository specialOfferReadRepository)
        {
            _specialOfferReadRepository = specialOfferReadRepository;
        }

        public async Task<GetByIdSpecialOfferResponse> Handle(GetByIdSpecialOfferRequest request, CancellationToken cancellationToken)
        {
            var specialOffer = _specialOfferReadRepository
                                .GetWhere(so => so.Id == Guid.Parse(request.Id),false)
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
                                }).FirstOrDefault();

            return new()
            {
                SpecialOffer = specialOffer,
            };
        }
    }
}
