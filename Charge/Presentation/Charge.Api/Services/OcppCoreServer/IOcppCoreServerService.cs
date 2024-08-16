using GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStartTransaction;
using GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStopTransaction;

namespace GCharge.Api.Services.OcppCoreServer
{
    public interface IOcppCoreServerService
    {
        Task<RemoteStartTransactionResponse> RemoteStartTransaction(RemoteStartTransactionRequest request);
        Task<RemoteStopTransactionResponse> RemoteStopTransaction(RemoteStopTransactionRequest request);
    }
}
