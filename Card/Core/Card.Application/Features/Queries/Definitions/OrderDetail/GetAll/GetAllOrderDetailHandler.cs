using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.OrderDetail.GetAll
{
    public class GetAllOrderDetailHandler : IRequestHandler<GetAllOrderDetailRequest, GetAllOrderDetailResponse>
    {
        readonly IOrderDetailReadRepository _orderDetailReadRepository; 

        public GetAllOrderDetailHandler(IOrderDetailReadRepository orderDetailReadRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository; 
        }

        public async Task<GetAllOrderDetailResponse> Handle(GetAllOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetailQuery = _orderDetailReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                orderDetailQuery = orderDetailQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                orderDetailQuery = orderDetailQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var orderDetails = await orderDetailQuery.Select(o => new OrderDetailVM
            {
                Id = o.Id.ToString(),
                CreatedDate = o.CreatedDate,
                CardId = o.CardId.ToString(),
                Description = o.Description,
                OrderId = o.OrderId.ToString(),
                PurchasedForStaffId = o.PurchasedForStaffId.ToString(),
                TotalTaxAmount = o.TotalTaxAmount,
                TaxRate = o.TaxRate, 
                Quantity = o.Quantity,
                TotalAmount = o.TotalAmount,
                UnitPrice = o.UnitPrice,
                BranchId = o.BranchId.ToString(),
                CompanyId = o.CompanyId.ToString(),
                BranchName = o.Branch.Name,
                CompanyName = o.Branch.Name,
                CardName = o.Card.Name,
                PurchasedFor = o.Staff.Name, 

            }).ToListAsync(cancellationToken); 

            var totalCount = orderDetails.Count;

            var response = orderDetails.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllOrderDetailResponse
            {
                TotalCount = totalCount,
                OrderDetails = response
            };
        }
    }
}
