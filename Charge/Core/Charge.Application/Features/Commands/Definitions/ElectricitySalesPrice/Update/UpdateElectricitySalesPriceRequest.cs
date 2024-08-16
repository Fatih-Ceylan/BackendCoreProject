using MediatR;

namespace GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Update
{
    public class UpdateElectricitySalesPriceRequest: IRequest<UpdateElectricitySalesPriceResponse>
    {
        public string Id { get; set; }
        public string? ChargePointId { get; set; }
        public string Title { get; set; }
        public decimal PricePerKWh { get; set; }
        public int VatRate { get; set; } = 20;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDefault { get; set; }
    }
}
