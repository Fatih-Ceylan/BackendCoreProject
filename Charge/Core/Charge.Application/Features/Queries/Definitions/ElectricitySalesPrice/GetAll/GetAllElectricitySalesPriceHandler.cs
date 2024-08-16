using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.ElectricitySalesPrice.GetAll
{
    public class GetAllElectricitySalesPriceHandler : IRequestHandler<GetAllElectricitySalesPriceRequest, GetAllElectricitySalesPriceResponse>
    {
        readonly IElectricitySalesPriceReadRepository _electricitySalesPriceReadRepository;

        public GetAllElectricitySalesPriceHandler(IElectricitySalesPriceReadRepository electricitySalesPriceReadRepository)
        {
            _electricitySalesPriceReadRepository = electricitySalesPriceReadRepository;
        }

        public async Task<GetAllElectricitySalesPriceResponse> Handle(GetAllElectricitySalesPriceRequest request, CancellationToken cancellationToken)
        {
            var query = _electricitySalesPriceReadRepository.GetAllDeletedStatus(false, false)
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
                                                       IsDefault = ep.IsDefault,
                                                   }).ToList();

            return new GetAllElectricitySalesPriceResponse
            {
                TotalCount = query.Count,
                ElectricitySalesPrices = query
            };
        }

    }
}