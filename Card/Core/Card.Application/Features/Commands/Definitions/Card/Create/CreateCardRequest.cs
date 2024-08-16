using MediatR;

namespace Card.Application.Features.Commands.Definitions.Card.Create
{
    public class CreateCardRequest : IRequest<CreateCardResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TaxRate { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
