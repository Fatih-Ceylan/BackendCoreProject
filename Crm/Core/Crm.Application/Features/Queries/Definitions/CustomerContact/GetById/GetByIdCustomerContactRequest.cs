using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerContact.GetById
{
    public class GetByIdCustomerContactRequest : IRequest<GetByIdCustomerContactResponse>
    {
        public string Id { get; set; }
    }
}
