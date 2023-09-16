using GuzellikSalonuInterfaces.Abstract;
using GuzellikSalonuInterfaces.Email;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces.Concrete
{
    public class RabbitMqClientService : IRabbitMqClientService
    {
        private readonly RabbitMqClientService _rabbitMqClientService;
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "SendEmailDirectExchange";
        public static string RoutingEmail = "send-email";
        public static string queveName = "queve-sendemail";
        private readonly ILogger<RabbitMqClientService> _logger;

        public RabbitMqClientService(ConnectionFactory connectionFactory, ILogger<RabbitMqClientService> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;


        }


        public IModel Connect()
        {

            _connection = _connectionFactory.CreateConnection();
            if (_channel is { IsOpen: true })
            {
                return _channel;
            }
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);
            _channel.QueueDeclare(queveName, true, false, false, null);
            _channel.QueueBind(exchange: ExchangeName,
                queue: queveName,
                routingKey: RoutingEmail
                );
            _logger.LogInformation("RabbitMq İle Bağlantı Kuruldu");
            return _channel;
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();

            _connection?.Close();
            _connection?.Dispose();

            _logger.LogInformation("RabbitMQ İle Bağlantı Koparıldı");
        }

        public bool Publish(MailRequest mailRequest)
        {
            throw new NotImplementedException();
        }
    }
}
