using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetById
{
    public class GetByIdOrderDetailHandler : IRequestHandler<GetByIdOrderDetailRequest, GetByIdOrderDetailResponse>
    {
        readonly IOrderDetailReadRepository _orderDetailReadRepository;

        public GetByIdOrderDetailHandler(IOrderDetailReadRepository orderDetailReadRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository;
        }

        public async Task<GetByIdOrderDetailResponse> Handle(GetByIdOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = _orderDetailReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new OrderDetailVM
                            {
                                Id = c.Id.ToString(),
                                CreatedDate = c.CreatedDate,
                                CardId = c.CardId.ToString(),
                                Description = c.Description,
                                OrderId = c.OrderId.ToString(),
                                PurchasedForStaffId = c.PurchasedForStaffId.ToString(),
                                Quantity = c.Quantity,
                                TotalAmount = c.TotalAmount,
                                UnitPrice = c.UnitPrice,
                                CompanyId = c.CompanyId.ToString(),
                                CompanyName = c.Branch.Company.Name,
                                BranchName = c.Branch.Name,
                                BranchId = c.BranchId.ToString()

                            }).FirstOrDefault();

            return new()
            {
                OrderDetail = orderDetail
            };
        }
    }
}
