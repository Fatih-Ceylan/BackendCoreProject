using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OCPP.Core.Server.Messages_OCPP16;
using System;

namespace OCPP.Core.Server
{
    public partial class ControllerOCPP16
    {
        public void HandleRemoteStartTransaction(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            Logger.LogInformation("RemoteStartTransaction answer: ChargePointId={0} / MsgType={1} / ErrCode={2}", ChargePointStatus.Id, msgIn.MessageType, msgIn.ErrorCode);

            try
            {
                RemoteStartTransactionResponse remoteStartTransactionResponse = DeserializeMessage<RemoteStartTransactionResponse>(msgIn);
                Logger.LogInformation("RemoteStartTransaction => Answer status: {0}", remoteStartTransactionResponse?.Status);
                WriteMessageLog(ChargePointStatus?.Id, null, msgOut.Action, remoteStartTransactionResponse?.Status.ToString(), msgIn.ErrorCode);

                if (msgOut.TaskCompletionSource != null)
                {
                    // Set API response as TaskCompletion-result
                    string apiResult = "{\"status\": " + JsonConvert.ToString(remoteStartTransactionResponse.Status.ToString()) + "}";
                    Logger.LogTrace("HandleRemoteStartTransaction => API response: {0}", apiResult);

                    msgOut.TaskCompletionSource.SetResult(apiResult);
                }
            }
            catch (Exception exp)
            {
                Logger.LogError(exp, "HandleRemoteStartTransaction => Exception: {0}", exp.Message);
            }
        }

    }
}
