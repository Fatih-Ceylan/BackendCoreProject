using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.ElectricitySalesPrice.GetById
{
    public class GetByIdElectricitySalesPriceHandler : IRequestHandler<GetByIdElectricitySalesPriceRequest, GetByIdElectricitySalesPriceResponse>
    {
        readonly IElectricitySalesPriceReadRepository _electricitySalesPriceReadRepository;

        public GetByIdElectricitySalesPriceHandler(IElectricitySalesPriceReadRepository electricitySalesPriceReadRepository)
        {
            _electricitySalesPriceReadRepository = electricitySalesPriceReadRepository;
        }

        public async Task<GetByIdElectricitySalesPriceResponse> Handle(GetByIdElectricitySalesPriceRequest request, CancellationToken cancellationToken)
        {
            var electricitySalesPrice = _electricitySalesPriceReadRepository
                           .GetWhere(ep => ep.Id == Guid.Parse(request.Id), false)
                           .Select(ep => new ElectricitySalesPriceVM
                           {
                               Id = ep.Id.ToString(),
                               ChargePointId = ep.ChargePoint != null ? ep.ChargePoint.ChargePointId : null,
                               ChargePointName = ep.ChargePoint != null ? ep.ChargePoint.Name : null,
                               Title = ep.Title,
                               PricePerKWh = ep.PricePerKWh,
                               VatRate = ep.VatRate,
                               StartDate = ep.StartDate,
                               EndDate = ep.EndDate,
                               IsDefault = ep.IsDefault
                           }).FirstOrDefault();

            return new()
            {
                ElectricitySalesPriceVM = electricitySalesPrice
            };
        }
    }
}
