using MediatR;

namespace GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Create
{
    public class CreateElectricitySalesPriceRequest : IRequest<CreateElectricitySalesPriceResponse>
    {
        public string Title { get; set; }
        public string ChargePointId { get; set; }

        public decimal PricePerKWh { get; set; }
        public int VatRate { get; set; } = 20;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDefault { get; set; }
    }
}
