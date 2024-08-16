using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerOffer.GetAll
{
    public class GetAllCustomerOfferHandler : IRequestHandler<GetAllCustomerOfferRequest, GetAllCustomerOfferResponse>
    {
        readonly ICustomerOfferReadRepository _customerOfferReadRepository;

        public GetAllCustomerOfferHandler(ICustomerOfferReadRepository customerOfferReadRepository)
        {
            _customerOfferReadRepository= customerOfferReadRepository;
        }
        public   Task<GetAllCustomerOfferResponse> Handle(GetAllCustomerOfferRequest request, CancellationToken cancellationToken)
        {
            var query = _customerOfferReadRepository.GetAllDeletedStatusDesc(false)
              .Select(co => new CustomerOfferVM
              {
                  Id = co.Id.ToString(),
                  CreatedDate = co.CreatedDate,
              });

            var totalCount = query.Count();
            var customeroffers = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerOfferResponse
            {
                TotalCount = totalCount,
                customerOfferVM = customeroffers,
            });
        }
    }
}
