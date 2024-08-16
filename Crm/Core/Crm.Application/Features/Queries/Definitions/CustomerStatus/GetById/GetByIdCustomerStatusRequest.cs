using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerStatus.GetById
{
    public class GetByIdCustomerStatusRequest : IRequest<GetByIdCustomerStatusResponse>
    {
        public string Id { get; set; }
    }
}
