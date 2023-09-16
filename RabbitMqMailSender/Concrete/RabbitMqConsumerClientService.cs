using GuzellikSalonuInterfaces.Concrete;
using GuzellikSalonuInterfaces.Email;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMqMailSenderWorkerService.Concrete
{
    public class RabbitMqConsumerClientService : BackgroundService
    {
        private readonly ILogger<RabbitMqConsumerClientService> _logger;
        private readonly RabbitMqConsumerClientService _rabbitMqClientsService;
        private readonly IServiceProvider _serviceProvider;
        private IModel _channel;
        private readonly RabbitMqClientService _rabbitMqClientService;
        public RabbitMqConsumerClientService(ILogger<RabbitMqConsumerClientService> logger, RabbitMqConsumerClientService rabbitMqClientsService, IServiceProvider serviceProvider, RabbitMqClientService rabbitMqClientService)
        {
            _logger = logger;
            _rabbitMqClientsService = rabbitMqClientsService;
            _serviceProvider = serviceProvider;
            _rabbitMqClientService = rabbitMqClientService;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqClientService.Connect();
            _channel.BasicQos(0, 1, false);


            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume
                (
                RabbitMqClientService.queveName,
                autoAck:false,
                consumer:consumer
                );
            consumer.Received += Consumer_Received;
            return Task.CompletedTask;//TODO burada kaldımmmm
        }


        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            
            var createEmailMessage =JsonSerializer.Deserialize<MailRequest>(Encoding.UTF8.GetString(@event.Body.ToArray()));
           
            var baseurl = "https://localhost:7137/User/denememailtest";
            using(var httpClient = new HttpClient())
            {//TODO Buralarda mail gönderme işlemlerini yapıcazz...
                var response = await httpClient.PostAsync(baseurl,null);
                if(response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("mailler Yollandı");
                    _channel.BasicAck(@event.DeliveryTag, false);

                }
            }
            
        }
    }
}
