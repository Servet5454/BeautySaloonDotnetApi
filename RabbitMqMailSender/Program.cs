
using RabbitMQ.Client;
using RabbitMqMailSender;
using RabbitMqMailSenderWorkerService.Abstract;
using RabbitMqMailSenderWorkerService.Concrete;
using RabbitMqMailSenderWorkerService.EmailModels;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        services.AddSingleton<RabbitMqClient>();
        services.AddSingleton<EmailSettings>();
        services.AddSingleton<EmailService>();
        IConfiguration configuration = hostContext.Configuration;
       

        services.AddSingleton(sp => new ConnectionFactory()
        {

            Uri = new Uri(configuration.GetConnectionString("RabbitMQ")),
            DispatchConsumersAsync = true
        });
        services.AddHostedService<RabbitMqConsumerClientService>();
    })
    .Build();

host.Run();

