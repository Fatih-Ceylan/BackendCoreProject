using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.Order.GetAll
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderRequest, GetAllOrderResponse>
    {
        readonly IOrderReadRepository _orderReadRepository; 

        public GetAllOrderHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository; 
        }

        public async Task<GetAllOrderResponse> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
        {
            var orderQuery = _orderReadRepository.GetAllDeletedStatusDesc(false);

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                orderQuery = orderQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                orderQuery = orderQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var orders = await orderQuery.Select(c => new OrderVM
            {
                Id = c.Id.ToString(),
                CreatedDate = c.CreatedDate,
                AddressId = c.AddressId.ToString(),
                BuyerId = c.BuyerId.ToString(),
                Description = c.Description,
                GeneralTotalAmount = c.GeneralTotalAmount,
                GeneralTotalTaxAmount = c.GeneralTotalTaxAmount,
                InvoiceId = c.InvoiceId.ToString(),
                Status = c.Status.Value,
                OrderNumber = c.OrderNumber.ToString(),
                BranchId = c.BranchId.ToString(),
                CompanyId = c.CompanyId.ToString(),
                BranchName = c.Branch.Name,
                CompanyName = c.Branch.Company.Name,

            }).ToListAsync(cancellationToken); 

            var totalCount = orders.Count;

            var response = orders.Skip(request.Page * request.Size).Take(request.Size).ToList();
             
            return new GetAllOrderResponse
            {
                TotalCount = totalCount,
                Orders = response
            };
        }
    }
}
