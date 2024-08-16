using MediatR;

namespace Card.Application.Features.Commands.Definitions.Card.Update
{
    public class UpdateCardRequest : IRequest<UpdateCardResponse>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? TaxRate { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
