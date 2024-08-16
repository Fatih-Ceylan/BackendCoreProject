using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.RabbitMQ;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage<T>(T message)
        {
            var connectionHost = _configuration.GetSection("RabbitMQConfiguration:Connection").Value;
            var factory = new ConnectionFactory
            {
                HostName = connectionHost
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("staff", exclusive: false, autoDelete: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "staff", body: body);

        }
    }
}
