using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivity.GetById
{
    public class GetByIdCustomerActivityRequest : IRequest<GetByIdCustomerActivityResponse>
    {
        public string Id { get; set; }
    }
}
