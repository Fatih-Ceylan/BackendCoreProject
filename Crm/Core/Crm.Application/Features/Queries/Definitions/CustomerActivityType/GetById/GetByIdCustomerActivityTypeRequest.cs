using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityType.GetById
{
    public class GetByIdCustomerActivityTypeRequest : IRequest<GetByIdCustomerActivityTypeResponse>
    {
        public string Id { get; set; }
    }
}
