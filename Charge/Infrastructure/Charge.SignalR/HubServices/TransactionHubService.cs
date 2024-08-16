using GCharge.Application.Abstractions.Hubs;
using GCharge.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GCharge.SignalR.HubServices
{
    public class TransactionHubService : ITransactionHubService
    {
        readonly IHubContext<TransactionHub> _hubContext;

        public TransactionHubService(IHubContext<TransactionHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMeterValuesAsync(string meterValues)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.TransactionSentMessage, meterValues);
        }

    }
}