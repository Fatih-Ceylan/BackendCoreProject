using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.Repositories.ReadRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListByDate
{
    public class GetDetailedListByDateHandler : IRequestHandler<GetDetailedListByDateRequest, GetDetailedListByDateResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderDetailReadRepository _orderDetailReadRepository;
        readonly IBranchService _branchService;

        public GetDetailedListByDateHandler(IOrderReadRepository orderReadRepository, IOrderDetailReadRepository orderDetailReadRepository, IBranchService branchService)
        {
            _orderReadRepository = orderReadRepository;
            _orderDetailReadRepository = orderDetailReadRepository;
            _branchService = branchService;
        }

        public async Task<GetDetailedListByDateResponse> Handle(GetDetailedListByDateRequest request, CancellationToken cancellationToken)
        {
            var branches = await _branchService.GetAllActiveBranches();

            IQueryable<T.Order> orderQuery;

            if (request.CreatedDate != OrderDateFilter.All)
            {

                if (request.CreatedDate == OrderDateFilter.OneWeek)
                {
                    orderQuery = _orderReadRepository.GetAllDeletedStatus().Where(o => o.CreatedDate >= DateTime.Now.AddDays(7));
                }

                if (request.CreatedDate == OrderDateFilter.OneMonth)
                {
                    orderQuery = _orderReadRepository.GetAllDeletedStatus().Where(o => o.CreatedDate >= DateTime.Now.AddDays(30));
                }

                if (request.CreatedDate == OrderDateFilter.ThreeMonths)
                {
                    orderQuery = _orderReadRepository.GetAllDeletedStatus().Where(o => o.CreatedDate >= DateTime.Now.AddDays(90));
                } 
            }
            else
            {
                orderQuery = _orderReadRepository.GetAllDeletedStatus();
            }

            throw new NotImplementedException();
        }
    }
}
