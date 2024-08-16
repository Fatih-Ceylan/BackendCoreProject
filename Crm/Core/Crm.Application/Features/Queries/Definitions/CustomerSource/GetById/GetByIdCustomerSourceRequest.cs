using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSource.GetById
{
    public class GetByIdCustomerSourceRequest : IRequest<GetByIdCustomerSourceResponse>
    {
        public string Id { get; set; }
    }
}
