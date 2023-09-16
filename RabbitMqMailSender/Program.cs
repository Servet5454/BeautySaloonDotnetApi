using GuzellikSalonuInterfaces.Abstract;
using GuzellikSalonuInterfaces.Concrete;
using RabbitMQ.Client;
using RabbitMqMailSender;
using RabbitMqMailSenderWorkerService.Abstract;
using RabbitMqMailSenderWorkerService.Concrete;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        services.AddSingleton<RabbitMqConsumerClientService>();
        services.AddSingleton<RabbitMqClientService>();
        IConfiguration configuration = hostContext.Configuration;
       

        services.AddSingleton(sp => new ConnectionFactory()
        {

            Uri = new Uri(configuration.GetConnectionString("RabbitMQ")),
            DispatchConsumersAsync = true
        });
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();

