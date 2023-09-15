using GuzellikSalonuInterfaces.Concrete;
using RabbitMQ.Client;
using RabbitMqMailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return _rabbitMqClientsService.ExecuteAsync(stoppingToken);//todo burada kaldımmmm
        }
    }
}
