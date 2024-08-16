using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerContact.GetByCustomerId
{
    public  class GetByCustomerIdRequest : IRequest<GetByCustomerIdResponse>
    {
        public string Id { get; set; }
    }
}
