using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerRepresentative.GetById
{
    public  class GetByIdCustomerRepresentativeRequest : IRequest<GetByIdCustomerRepresentativeResponse>
    {
        public string Id { get; set; }
    }
}
