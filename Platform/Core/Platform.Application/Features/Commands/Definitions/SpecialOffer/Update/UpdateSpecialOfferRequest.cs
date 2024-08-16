using MediatR;

namespace Platform.Application.Features.Commands.Definitions.SpecialOffer.Update
{
    public class UpdateSpecialOfferRequest : IRequest<UpdateSpecialOfferResponse>
    {
        public string Id { get; set; }
        public Guid CompanyId { get; set; }

        public Guid GModuleId { get; set; }

        public decimal DiscountRate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }
    }
}