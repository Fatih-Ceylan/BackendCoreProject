namespace GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStopTransaction
{
    public class RemoteStopTransactionRequest
    {
        public string ChargePointId { get; set; }

        public int ConnectorId { get; set; }
    }
}