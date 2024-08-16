using GCharge.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace GCharge.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication) {

            webApplication.MapHub<TransactionHub>("/transactions-hub");
        }
    }
}