using GCharge.Application.Features.Queries.Definitions.UserChargeTag.GetAll;
using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.UserUserChargeTag.GetAll
{
    public class GetAllUserChargeTagHandler : IRequestHandler<GetAllUserChargeTagRequest, GetAllUserChargeTagResponse>
    {
        readonly IUserChargeTagReadRepository _userChargeTagReadRepository;

        public GetAllUserChargeTagHandler(IUserChargeTagReadRepository userChargeTagReadRepository)
        {
            _userChargeTagReadRepository = userChargeTagReadRepository;
        }

        public async Task<GetAllUserChargeTagResponse> Handle(GetAllUserChargeTagRequest request, CancellationToken cancellationToken)
        {
            var query = _userChargeTagReadRepository.GetAll(false)
                                                   .Select(cp => new UserChargeTagVM
                                                   {
                                                       UserId = cp.UserId,
                                                       UserName = cp.User != null ? cp.User.UserName : string.Empty,
                                                       TagId = cp.TagId,
                                                       TagName = cp.Tag != null ? cp.Tag.TagName : string.Empty,
                                                       ExpiryDate = cp.Tag != null ? cp.Tag.ExpiryDate : null,
                                                       Blocked = cp.Tag != null ? cp.Tag.Blocked : null
                                                   }).ToList();

            return new GetAllUserChargeTagResponse
            {
                TotalCount = query.Count,
                UserChargeTags = query
            };
        }

    }
}