using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.ChargeTag.GetAll
{
    public class GetAllChargeTagHandler : IRequestHandler<GetAllChargeTagRequest, GetAllChargeTagResponse>
    {
        readonly IChargeTagReadRepository _chargeTagReadRepository;

        public GetAllChargeTagHandler(IChargeTagReadRepository chargeTagReadRepository)
        {
            _chargeTagReadRepository = chargeTagReadRepository;
        }

        public async Task<GetAllChargeTagResponse> Handle(GetAllChargeTagRequest request, CancellationToken cancellationToken)
        {
            var query = _chargeTagReadRepository.GetAll(false)
                                                  .Select(cp => new ChargeTagVM
                                                  {
                                                      TagId = cp.TagId,
                                                      TagName = cp.TagName,
                                                      ParentTagId = cp.ParentTagId,
                                                      ExpiryDate = cp.ExpiryDate,
                                                      Blocked = cp.Blocked
                                                  }).ToList();
            return new()
            {
                TotalCount = query.Count(),
                ChargeTags = query.ToList()
            };
        }
    }
}
