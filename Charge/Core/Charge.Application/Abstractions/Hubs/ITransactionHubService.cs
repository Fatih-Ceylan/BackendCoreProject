namespace GCharge.Application.Abstractions.Hubs
{
    public interface ITransactionHubService
    {
        Task SendMeterValuesAsync(string meterValues); 
    }
}
