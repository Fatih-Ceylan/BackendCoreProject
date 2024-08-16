namespace Platform.Application.Features.Commands.Definitions.Order.UpdateCargoTrackingNo
{
    public class UpdateCargoTrackingNoResponse
    {
        public string OrderId { get; set; }

        public string OrderIdFromModule { get; set; }

        public string CargoTrackingNo { get; set; }

        public List<string> MessageList { get; set; }

    }
}