using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.Order;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Queries.Definitions.Order.GetAll
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
            var query = _orderReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted);


            if (request.OrderDate != OrderDateFilter.All)
            {

                DateTime dateThreshold = DateTime.Now;
                switch (request.OrderDate)
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

                };

                query = query.Where(o => o.CreatedDate >= dateThreshold);
            }

            if (request.OrderStatus != OrderStatus.All)
            {
                query = query.Where(o => o.Status == request.OrderStatus);
            }

            var queryVm = query.Select(o => new OrderVM
                                {
                                    Id = o.Id.ToString(),
                                    CreatedDate = o.CreatedDate,
                                    OrderIdFromModule = o.OrderIdFromModule.ToString(),                    
                                    OrderNo = o.OrderNo,
                                    ModuleName = o.ModuleName,
                                    BuyerInvoiceTitle = o.BuyerInvoiceTitle,
                                    BuyerInvoiceAddress = o.BuyerInvoiceAddress,
                                    BuyerDeliverAddress = o.BuyerDeliverAddress,
                                    BuyerInvoiceDistrict = o.BuyerInvoiceDistrict,
                                    BuyerInvoiceCity = o.BuyerInvoiceCity,
                                    BuyerInvoiceCountry = o.BuyerInvoiceCountry,
                                    BuyerInvoiceTaxNo = o.BuyerInvoiceTaxNo,
                                    BuyerInvoiceTaxOffice = o.BuyerInvoiceTaxOffice,
                                    GeneralTotalDiscountAmount = o.GeneralTotalDiscountAmount,
                                    GeneralTotalTaxAmount = o.GeneralTotalTaxAmount,
                                    GeneralTotalAmount = o.GeneralTotalAmount,
                                    Status = o.Status.ToString(),
                                    Description = o.Description,
                                    CargoCompanyName = o.CargoCompanyName,
                                    CargoTrackingNo = o.CargoTrackingNo,
                                    CompanyId = o.CompanyId.ToString(),
                                    CompanyName = o.Company.Name,
                                    CompanyUrlPath = o.Company.UrlPath
                                });

            var totalCount = queryVm.Count();
            var orders = request.DoPagination ? queryVm.Skip(request.Page * request.Size)
                                                       .Take(request.Size).ToList()
                                              : queryVm.ToList();

            return new()
            {
                TotalCount = totalCount,
                Orders = orders,
            };
        }
    }
}