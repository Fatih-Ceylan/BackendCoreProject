using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerType.GetById
{
    public class GetByIdCustomerTypeRequest : IRequest<GetByIdCustomerTypeResponse>
    {
        public string Id { get; set; }
    }
}
