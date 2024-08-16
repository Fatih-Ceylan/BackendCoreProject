using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Order.GetById
{
    public class GetByIdOrderHandler : IRequestHandler<GetByIdOrderRequest, GetByIdOrderResponse>
    {
        readonly IOrderReadRepository _orderReadRepository;

        public GetByIdOrderHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetByIdOrderResponse> Handle(GetByIdOrderRequest request, CancellationToken cancellationToken)
        {
            var order = _orderReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new OrderVM
                            {
                                Id = c.Id.ToString(),
                                CreatedDate = c.CreatedDate,
                                AddressId = c.AddressId.ToString(),
                                BuyerId = c.BuyerId.ToString(),
                                Description = c.Description,
                                OrderNumber = c.OrderNumber,
                                GeneralTotalAmount = c.GeneralTotalAmount,
                                GeneralTotalTaxAmount = c.GeneralTotalTaxAmount,
                                InvoiceId = c.InvoiceId.ToString(),
                                Status = c.Status.Value,
                                BranchId = c.BranchId.ToString(),
                                BranchName = c.Branch.Name,
                                CompanyId = c.CompanyId.ToString(),
                                CompanyName = c.Branch.Company.Name

                            }).FirstOrDefault();

            return new()
            {
                Order = order
            };
        }
    }
}
