using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.ElectricitySalesPrice.GetById
{
    public class GetByIdElectricitySalesPriceRequest: IRequest<GetByIdElectricitySalesPriceResponse>
    {
        public string Id { get; set; }

    }
}
