using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.OrderDetail;

namespace Platform.Application.Features.Queries.Definitions.OrderDetail.GetOrderDetailGroupsByOrderId
{
    public class GetOrderDetailGroupsByOrderIdHandler : IRequestHandler<GetOrderDetailGroupsByOrderIdRequest, GetOrderDetailGroupsByOrderIdResponse>
    {
        readonly IOrderDetailReadRepository _orderDetailReadRepository;

        public GetOrderDetailGroupsByOrderIdHandler(IOrderDetailReadRepository orderDetailReadRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository;
        }

        public async Task<GetOrderDetailGroupsByOrderIdResponse> Handle(GetOrderDetailGroupsByOrderIdRequest request, CancellationToken cancellationToken)
        {
            var orderDetailGroups = _orderDetailReadRepository.GetAllDeletedStatus(false, false)
                                                                          .Where(od => od.OrderId == Guid.Parse(request.OrderId))
                                                                          .GroupBy(od => new
                                                                          {
                                                                              od.ProductOrServiceName,
                                                                              od.UnitPrice,
                                                                              od.DiscountRate,
                                                                              od.TaxRate
                                                                          })
                                                                          .Select(g => new OrderDetailGroupVM
                                                                          {
                                                                              ProductOrServiceName = g.Key.ProductOrServiceName,
                                                                              Quantity = g.Sum(x => x.Quantity),
                                                                              UnitPrice = g.Key.UnitPrice,
                                                                              DiscountRate = g.Key.DiscountRate,
                                                                              TaxRate = g.Key.TaxRate,
                                                                              DiscountAmount = g.Sum(x => x.DiscountAmount),
                                                                              TaxAmount = g.Sum(x => x.TaxAmount),
                                                                              TotalAmount = g.Sum(x => x.TotalAmount)
                                                                          })
                                                                          .ToList();

            
            return new()
            {
                TotalCount = orderDetailGroups.Count,
                OrderDetailGroups = orderDetailGroups,
            };
            
        }
    }
}