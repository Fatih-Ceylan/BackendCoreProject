using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityStatus.GetById
{
    public  class GetByIdCustomerActivityStatusRequest : IRequest<GetByIdCustomerActivityStatusResponse>
    {
        public string Id { get; set; }
    }
}
