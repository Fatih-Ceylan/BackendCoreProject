using AutoMapper;
using BaseProject.Application.Abstractions.Services.Definitions;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using Card.Application.VMs;
using MediatR;
using Platform.Application.Abstractions.Services.Definitions;
using Platform.Application.DTOs.Definitions.Order;
using Platform.Application.DTOs.Definitions.OrderDetail;
using Platform.Application.VMs.Definitions.OrderDetail;
using Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.OrderDetail.Create
{
    public class CreateOrderDetailHandler : IRequestHandler<CreateOrderDetailRequest, CreateOrderDetailResponse>
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;
        readonly IAddressWriteRepository _addressWriteRepository; 
        readonly IMapper _mapper;
        readonly ICardReadRepository _cardReadRepository;
        readonly IOrderDetailService _orderDetailService;
        readonly IOrderService _orderService;
        readonly IBranchService _branchService;
        readonly IStaffReadRepository _staffReadRepository;
        readonly ICurrentUserService _currentUserService;

        public CreateOrderDetailHandler(IOrderWriteRepository orderWriteRepository, IOrderDetailWriteRepository orderDetailWriteRepository, IMapper mapper, IAddressWriteRepository addressWriteRepository, ICardReadRepository cardReadRepository, IOrderDetailService orderDetailService, IOrderService orderService, IBranchService branchService, IStaffReadRepository staffReadRepository, ICurrentUserService currentUserService)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderDetailWriteRepository = orderDetailWriteRepository;
            _mapper = mapper; 
            _addressWriteRepository = addressWriteRepository;
            _cardReadRepository = cardReadRepository;
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _branchService = branchService;
            _staffReadRepository = staffReadRepository;
            _currentUserService = currentUserService;
        }

        public async Task<CreateOrderDetailResponse> Handle(CreateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var branch = await _branchService.GetAllActiveBranchWithIds(request.Order.CompanyId, request.Order.BranchId);

            T.Order order = _mapper.Map<T.Order>(request.Order);

            var currentUser = await _currentUserService.GetCurrentUser();

            Random random = new Random();
            string orderNumber = random.Next(10000000, 100000000).ToString();
            order.OrderNumber = orderNumber;
            order.BuyerId = Guid.Parse(currentUser.Id);
            order.CreatedDate = DateTime.Now;
             
            Guid? orderAddressId = null;

            foreach (var addressVM in request.Addresses)
            {
                T.Address address = _mapper.Map<T.Address>(addressVM);
                address.CompanyId = Guid.Parse(addressVM.CompanyId);
                address.BranchId = Guid.Parse(addressVM.BranchId);
                await _addressWriteRepository.AddAsync(address);
                await _addressWriteRepository.SaveAsync();

                if (addressVM.AddressType == "Fatura Adresi")
                {
                    orderAddressId = address.Id;
                }
            }

            if (orderAddressId.HasValue)
            {
                order.AddressId = orderAddressId.Value;
            }
             
            var orderWithId = await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();

            List<T.OrderDetail> orderDetails = new List<T.OrderDetail>();

            CreateOrderDetailRequestDTO platformOrderDetail = new CreateOrderDetailRequestDTO
            {
                OrderDetails = new List<OrderDetailCreateVM>()
            };

            foreach (var orderDetailVM in request.OrderDetails)
            {
                T.OrderDetail orderDetail = _mapper.Map<T.OrderDetail>(orderDetailVM);

                var card = _cardReadRepository.GetWhere(x => x.Id == Guid.Parse(orderDetailVM.CardId))
                                              .Select(x => new CardVM { Name = x.Name, TaxRate = x.TaxRate })
                                              .FirstOrDefault();

                orderDetail.OrderId = orderWithId.Id;
                orderDetail.TotalAmount = (orderDetailVM.UnitPrice * orderDetailVM.Quantity) + (orderDetailVM.UnitPrice * card.TaxRate / 100);
                orderDetail.TotalTaxAmount = (orderDetailVM.UnitPrice * card.TaxRate / 100);
                orderDetail.TaxRate = card.TaxRate;
                orderDetail.CreatedDate = DateTime.Now;
                orderDetail.BranchId = Guid.Parse(orderDetailVM.BranchId);
                orderDetail.CompanyId = Guid.Parse(orderDetailVM.CompanyId);
                orderDetail.CreatedDate = DateTime.Now;
                orderDetail.PurchasedForStaffId = Guid.Parse(orderDetailVM.PurchasedForStaffId);

                order.GeneralTotalAmount += orderDetail.TotalAmount;
                order.GeneralTotalTaxAmount += orderDetail.TotalTaxAmount;

                var staff = _staffReadRepository.GetWhere(x => x.Id == Guid.Parse(orderDetailVM.PurchasedForStaffId))
                                                .Select(x => new StaffVM { Name = x.Name, LastName = x.LastName })
                                                .FirstOrDefault();

                var staffName = $"{staff.Name} {staff.LastName}";

                platformOrderDetail.OrderDetails.Add(new OrderDetailCreateVM
                {
                    OrderId = orderWithId.Id.ToString(),
                    ProductOrServiceName = card.Name,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice,
                    DiscountRate = 0,
                    DiscountAmount = 0,
                    TaxRate = orderDetail.TaxRate,
                    TaxAmount = orderDetail.TotalTaxAmount,
                    TotalAmount = orderDetail.TotalAmount,
                    PurchasedForStaffName = staffName,
                    Description = orderDetail.Description
                });

                orderDetails.Add(orderDetail);
            }
             
            order.GeneralTotalAmount = orderDetails.Sum(od => od.TotalAmount);
            order.GeneralTotalTaxAmount = orderDetails.Sum(od => od.TotalTaxAmount);

            _orderWriteRepository.Update(order);
            await _orderWriteRepository.SaveAsync();

            CreateOrderRequestDTO platformOrder = new CreateOrderRequestDTO();

            platformOrder.OrderIdFromModule=order.Id.ToString();
            platformOrder.OrderNo = order.OrderNumber;
            platformOrder.ModuleName = "Card";
            platformOrder.BuyerInvoiceTitle = branch.CompanyName;
            platformOrder.BuyerDeliverAddress = order.Address.AddressLine;
            platformOrder.BuyerInvoiceAddress = order.Address.AddressLine;
            platformOrder.BuyerInvoiceDistrict = branch.DistrictName;
            platformOrder.BuyerInvoiceCity = branch.CityName;
            platformOrder.BuyerInvoiceCountry = branch.CountryName;
            platformOrder.BuyerInvoiceTaxNo = branch.TaxNo;
            platformOrder.BuyerInvoiceTaxOffice = branch.TaxOffice;
            platformOrder.GeneralTotalDiscountAmount = 0;
            platformOrder.Status = order.Status.Value;
            platformOrder.Description = order.Description;
            platformOrder.CargoCompanyName = "test";
            platformOrder.CargoTrackingNo = "test";
            platformOrder.CompanyId = currentUser.MasterCompanyIdFromPlatform; 
            platformOrder.GeneralTotalAmount = order.GeneralTotalAmount;
            platformOrder.GeneralTotalTaxAmount = order.GeneralTotalTaxAmount;

            var platformOrderResponse = await _orderService.Create(platformOrder);

            foreach (var detail in platformOrderDetail.OrderDetails)
            {
                detail.OrderId = platformOrderResponse.Id;
            }

            await _orderDetailService.Create(platformOrderDetail);

            await _orderDetailWriteRepository.AddRangeAsync(orderDetails);
            await _orderDetailWriteRepository.SaveAsync();

            var createdResponse = new CreateOrderDetailResponse();
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();
            createdResponse.OrderId = order.Id.ToString();

            return createdResponse;
        }


    }
}
