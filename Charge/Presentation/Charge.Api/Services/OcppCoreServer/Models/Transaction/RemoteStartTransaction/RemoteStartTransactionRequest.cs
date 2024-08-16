namespace GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStartTransaction
{
    public class RemoteStartTransactionRequest
    {
        public string ChargePointId { get; set; }
        
        public int ConnectorId { get; set; }
    }
}
