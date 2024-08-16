using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.VMs.Definitions;
using MediatR;

namespace GCharge.Application.Features.Queries.Definitions.ChargePoint.GetAll
{
    public class GetAllChargePointHandler : IRequestHandler<GetAllChargePointRequest, GetAllChargePointResponse>
    {
        readonly IChargePointReadRepository _chargePointReadRepository;
        readonly IConnectorStatusReadRepository _connectorStatusReadRepository;

        public GetAllChargePointHandler(IChargePointReadRepository chargePointReadRepository, IConnectorStatusReadRepository connectorStatusReadRepository)
        {
            _chargePointReadRepository = chargePointReadRepository;
            _connectorStatusReadRepository = connectorStatusReadRepository;
        }

        public async Task<GetAllChargePointResponse> Handle(GetAllChargePointRequest request, CancellationToken cancellationToken)
        {
            var query = _chargePointReadRepository.GetAll(false)
                                                  .Select(cp => new ChargePointVM
                                                  {
                                                      ChargePointId = cp.ChargePointId,
                                                      Name = cp.Name,
                                                      Comment = cp.Comment,
                                                      Latitude = cp.Latitude,
                                                      Longitude = cp.Longitude,
                                                      ConnectorStatuses = _connectorStatusReadRepository.GetAll(false)
                                                         .Where(cs => cs.ChargePointId == cp.ChargePointId)
                                                         .Select(cs => new ConnectorStatusVM
                                                         {
                                                             ConnectorId = cs.ConnectorId,
                                                         }).ToList()
                                                  });
            return new()
            {
                TotalCount = query.Count(),
                ChargePoints = query.ToList()
            };
        }
    }
}
