using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Customer.GetById
{
    public class GetByIdCustomerRequest : IRequest<GetByIdCustomerResponse>
    {
        public string Id { get; set; }
    }
}
