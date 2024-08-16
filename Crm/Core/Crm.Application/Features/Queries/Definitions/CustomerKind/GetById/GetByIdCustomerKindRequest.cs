using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerKind.GetById
{
    public class GetByIdCustomerKindRequest : IRequest<GetByIdCustomerKindResponse>
    {
        public string Id { get; set; }
    }
}
