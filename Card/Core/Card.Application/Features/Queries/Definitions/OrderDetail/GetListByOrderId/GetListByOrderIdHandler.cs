using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetListByOrderId
{
    public class GetListByOrderIdHandler : IRequestHandler<GetListByOrderIdRequest, GetListByOrderIdResponse>
    {
        readonly IOrderDetailReadRepository _orderDetailReadRepository;

        public GetListByOrderIdHandler(IOrderDetailReadRepository orderDetailReadRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository;
        }

        public Task<GetListByOrderIdResponse> Handle(GetListByOrderIdRequest request, CancellationToken cancellationToken)
        {
            var detailedOrders = _orderDetailReadRepository.GetWhere(o => o.OrderId.ToString() == request.Id, false)
                                                   .Select(o => new OrderDetailVM
                                                   {
                                                       Id = o.Id.ToString(),
                                                       CreatedDate = o.CreatedDate,
                                                       CardId = o.CardId.ToString(),
                                                       Description = o.Description,
                                                       OrderId = o.OrderId.ToString(),
                                                       PurchasedForStaffId = o.PurchasedForStaffId.ToString(),
                                                       Quantity = o.Quantity,
                                                       TotalAmount = o.TotalAmount,
                                                       UnitPrice = o.UnitPrice,
                                                       BranchId = o.BranchId.ToString(),
                                                       BranchName = o.Branch.Name,
                                                       CompanyId = o.CompanyId.ToString(),
                                                       CompanyName=o.Branch.Company.Name,
                                                       TaxRate = o.TaxRate,
                                                       TotalTaxAmount = o.TotalTaxAmount,

                                                   }).ToList();

            var totalCount = detailedOrders.Count();

            return Task.FromResult(new GetListByOrderIdResponse
            {
                OrderDetails = detailedOrders,
                Message = CommandResponseMessage.Success.ToString()
            });
        }
    }
}
