using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListById
{
    public class GetDetailedListByIdHandler : IRequestHandler<GetDetailedListByIdRequest, GetDetailedListByIdResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IBranchService _branchService;

        public GetDetailedListByIdHandler(IOrderReadRepository orderReadRepository, IBranchService branchService)
        {
            _orderReadRepository = orderReadRepository;
            _branchService = branchService;
        }

        public async Task<GetDetailedListByIdResponse> Handle(GetDetailedListByIdRequest request, CancellationToken cancellationToken)
        {
            var branches = await _branchService.GetAllActiveBranches(); 

            var orderQuery = _orderReadRepository.GetWhere(o => o.Id.ToString() == request.Id, false); 

            var orders = await orderQuery.Select(o => new DetailedOrderListVM
            {
                Id = o.Id.ToString(),
                AddressId = o.AddressId.ToString(),
                BuyerId = o.BuyerId.ToString(),
                Description = o.Description,
                GeneralTotalAmount = o.GeneralTotalAmount,
                GeneralTotalTaxAmount = o.GeneralTotalTaxAmount,
                InvoiceId = o.InvoiceId.ToString(),
                OrderNumber = o.OrderNumber.ToString(),
                Status = o.Status.Value,
                BranchId = o.BranchId.ToString(),
                BranchName = o.Branch.Name,
                CompanyId = o.CompanyId.ToString(),
                CompanyName = o.Branch.Company.Name,
                OrderDetails = o.OrderDetails.Where(x => x.OrderId == o.Id && x.IsDeleted == false).Select(od => new OrderDetailVM
                {
                    Id = od.Id.ToString(),
                    CreatedDate = od.CreatedDate,
                    CardId = od.CardId.ToString(),
                    Description = od.Description,
                    OrderId = od.OrderId.ToString(),
                    PurchasedForStaffId = od.PurchasedForStaffId.ToString(),
                    Quantity = od.Quantity,
                    TotalAmount = od.TotalAmount,
                    TaxRate = od.TaxRate,
                    TotalTaxAmount = od.TotalTaxAmount,
                    UnitPrice = od.UnitPrice,
                    PurchasedFor = $"{od.Staff.Name} {od.Staff.LastName}",
                    CardName = od.Card.Name,
                    BranchId = od.BranchId.ToString(),
                    BranchName = od.Branch.Name,
                    CompanyName = od.Branch.Company.Name,
                    CompanyId = o.CompanyId.ToString(),

                }).ToList(),
            }).ToListAsync(cancellationToken); 

            var totalCount = orders.Count;

            var response = orders.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetDetailedListByIdResponse
            {

                DetailedOrders = response,
            };
        }
    }
}
