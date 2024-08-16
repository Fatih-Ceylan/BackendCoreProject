using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSector.GetById
{
    public class GetByIdCustomerSectorRequest : IRequest<GetByIdCustomerSectorResponse>
    {
        public string Id { get; set; }
    }
}
