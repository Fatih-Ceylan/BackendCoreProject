using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerAddress.GetById
{
    public class GetByIdCustomerAddressRequest : IRequest<GetByIdCustomerAddressResponse>
    {
        public string Id { get; set; }
    }
}
