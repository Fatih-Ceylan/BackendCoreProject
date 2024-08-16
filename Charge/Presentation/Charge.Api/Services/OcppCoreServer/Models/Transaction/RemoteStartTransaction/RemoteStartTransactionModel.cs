using Newtonsoft.Json;

namespace GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStartTransaction
{
    public class RemoteStartTransactionModel
    {
        [JsonProperty("connectorId")]
        public int ConnectorId { get; set; }

        [JsonProperty("idTag")]
        public string IdTag { get; set; }
    }
}
