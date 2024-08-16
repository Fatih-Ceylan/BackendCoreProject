using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OCPP.Core.Server.Messages_OCPP16;
using System;

namespace OCPP.Core.Server
{
    public partial class ControllerOCPP16
    {
        public void HandleRemoteStopTransaction(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            Logger.LogInformation("HandleRemoteStopTransaction answer: ChargePointId={0} / MsgType={1} / ErrCode={2}", ChargePointStatus.Id, msgIn.MessageType, msgIn.ErrorCode);

            try
            {
                RemoteStopTransactionResponse remoteStopTransactionResponse = DeserializeMessage<RemoteStopTransactionResponse>(msgIn);
                Logger.LogInformation("RemoteStopTransaction => Answer status: {0}", remoteStopTransactionResponse?.Status);
                WriteMessageLog(ChargePointStatus?.Id, null, msgOut.Action, remoteStopTransactionResponse?.Status.ToString(), msgIn.ErrorCode);

                if (msgOut.TaskCompletionSource != null)
                {
                    string apiResult = "{\"status\": " + JsonConvert.ToString(remoteStopTransactionResponse.Status.ToString()) + "}";
                    Logger.LogTrace("HandleRemoteStopTransaction => API response: {0}", apiResult);

                    msgOut.TaskCompletionSource.SetResult(apiResult);
                }
            }
            catch (Exception exp)
            {
                Logger.LogError(exp, "HandleRemoteStopTransaction => Exception: {0}", exp.Message);
            }
        }

    }
}
