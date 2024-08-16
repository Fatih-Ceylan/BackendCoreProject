using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityKind.GetById
{
    public  class GetByIdCustomerActivityKindRequest : IRequest<GetByIdCustomerActivityKindResponse>
    {
        public string Id { get; set; }
    }
}
