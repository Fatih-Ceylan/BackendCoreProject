using MediatR;

namespace Platform.Application.Features.Commands.Definitions.Order.UpdateCargoTrackingNo
{
    public class UpdateCargoTrackingNoRequest : IRequest<UpdateCargoTrackingNoResponse>
    {
        public string OrderId { get; set; }

        public string OrderIdFromModule { get; set; }

        public string CargoTrackingNo { get; set; }

    }
}