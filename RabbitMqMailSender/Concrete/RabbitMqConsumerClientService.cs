
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMqMailSender;
using RabbitMqMailSenderWorkerService.EmailModels;
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
        private readonly RabbitMqClient _rabbitMqClientsService;
        private readonly IServiceProvider _serviceProvider;
        private IModel _channel;
        private readonly RabbitMqClient _rabbitMqClientService;
        private readonly EmailService _emailService;
        public RabbitMqConsumerClientService(ILogger<RabbitMqConsumerClientService> logger, RabbitMqClient rabbitMqClientsService, IServiceProvider serviceProvider, EmailService emailService)
        {
            _logger = logger;
            _rabbitMqClientsService = rabbitMqClientsService;
            _serviceProvider = serviceProvider;
            _emailService = emailService;
        }



        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqClientsService.Connect();
            _channel.BasicQos(0, 1, false);


            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume
                (
                RabbitMqClient.queveName,
                autoAck: false,
                consumer: consumer
                );
            consumer.Received += Consumer_Received;
            return Task.CompletedTask;//TODO burada kaldımmmm
        }


        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {

             var createEmailMessage =JsonSerializer.Deserialize<MailRequest>(Encoding.UTF8.GetString(@event.Body.ToArray()));      
            var baseurl = "https://localhost:7137/User/GetAllCostumers";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(baseurl);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // JSON özellik adlarını büyük/küçük harf duyarlılığı olmADAN EŞLEŞTİRME ÖZELLİĞİNİ YAPIYORUZ BURADA.....
                    };

                    var customers = JsonSerializer.Deserialize<List<Costumer>>(responseContent, options);
                    var emailler =customers.Select(p=>p.CostumerEmail).ToList();
                    MailRequest mailRequest = new MailRequest();
                    
                    mailRequest.Subject = "BeautyElla Güzellik Salonu Dev Kampanya";
                    mailRequest.Body = await _emailService.GetHtmlContentAsync();
                    
                    for (int i = 0; i < emailler.Count; i++)
                    {
                        mailRequest.ToEmail = emailler[i];
                        await _emailService.SendEmailWithMimeAsync(mailRequest);
                    }

                   
                    _logger.LogInformation("mailler Yollandı");
                    _channel.BasicAck(@event.DeliveryTag, false);

                }
            }


        }
    }
}
