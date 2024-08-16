using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerOffer.GetById
{
    public class GetByIdCustomerOfferHandler : IRequestHandler<GetByIdCustomerOfferRequest, GetByIdCustomerOfferResponse>
    {
        readonly ICustomerOfferReadRepository _customerOfferReadRepository;

        public GetByIdCustomerOfferHandler(ICustomerOfferReadRepository customerOfferReadRepository)
        {
            _customerOfferReadRepository = customerOfferReadRepository;
        }

        public async  Task<GetByIdCustomerOfferResponse> Handle(GetByIdCustomerOfferRequest request, CancellationToken cancellationToken)
        {
            var customeroffers = _customerOfferReadRepository
                             .GetWhere(co => co.Id == Guid.Parse(request.Id), false)
                             .Select(co => new CustomerOfferVM
                             {
                                 Id = co.Id.ToString(),
                               
                          

                                 CreatedDate = co.CreatedDate
                             }).FirstOrDefault();



            return new()
            {
                customerOfferVM = customeroffers
            };
        }
    }
}
