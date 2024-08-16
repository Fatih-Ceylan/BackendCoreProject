using MediatR;

namespace GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Delete
{
    public class DeleteElectricitySalesPriceRequest: IRequest<DeleteElectricitySalesPriceResponse>
    {
        public string Id { get; set; }
    }
}
