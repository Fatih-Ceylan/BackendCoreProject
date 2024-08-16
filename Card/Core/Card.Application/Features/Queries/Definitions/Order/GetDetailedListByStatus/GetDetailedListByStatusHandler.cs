using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Queries.Definitions.Order.GetDetailedListByStatus
{
    public class GetDetailedListByStatusHandler : IRequestHandler<GetDetailedListByStatusRequest, GetDetailedListByStatusResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;
        readonly IBranchService _branchService;

        public GetDetailedListByStatusHandler(IOrderReadRepository orderReadRepository, IBranchService branchService)
        {
            _orderReadRepository = orderReadRepository;
            _branchService = branchService;
        }

        public async Task<GetDetailedListByStatusResponse> Handle(GetDetailedListByStatusRequest request, CancellationToken cancellationToken)
        {
            var branches = await _branchService.GetAllActiveBranches();

            IQueryable<T.Order> orderQuery = _orderReadRepository.GetAllDeletedStatus();

            if (request.Status != OrderStatus.All)
            {
                orderQuery = orderQuery.Where(o => o.Status == request.Status);
            }

            if (request.CreatedDate != OrderDateFilter.All)
            {
                DateTime dateThreshold = DateTime.Now;
                switch (request.CreatedDate)
                {
                    case OrderDateFilter.OneWeek:
                        dateThreshold = dateThreshold.AddDays(-7);
                        break;
                    case OrderDateFilter.OneMonth:
                        dateThreshold = dateThreshold.AddMonths(-1);
                        break;
                    case OrderDateFilter.ThreeMonths:
                        dateThreshold = dateThreshold.AddMonths(-3);
                        break;
                }
                orderQuery = orderQuery.Where(o => o.CreatedDate >= dateThreshold);
            }

            orderQuery = orderQuery.Where(x => (request.BranchId == null || request.BranchId == "SelectAll" || x.BranchId.ToString() == request.BranchId) && x.CompanyId.ToString() == request.CompanyId);

            if (orderQuery.Count() <= 0)
            {
                //todo sipariş listesinin boş olması durumunda düzgün exception fırlat 
                throw new FileNotFoundException();
            }
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
                    UnitPrice = od.UnitPrice,
                    PurchasedFor = $"{od.Staff.Name} {od.Staff.LastName}",
                    CardName = od.Card.Name,
                    BranchName = od.Branch.Name,
                    BranchId = od.BranchId.ToString(),
                    CompanyName = od.Branch.Company.Name,
                    CompanyId = o.CompanyId.ToString(),
                    TaxRate = od.TaxRate,
                    TotalTaxAmount = od.TotalTaxAmount,

                }).ToList(),
            }).ToListAsync(cancellationToken);

            var totalCount = orders.Count;

            var response = orders.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetDetailedListByStatusResponse
            {

                DetailedOrders = response,
            };

        }
    }
}
