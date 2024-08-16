namespace Utilities.Core.UtilityApplication.Abstractions.Services.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}
