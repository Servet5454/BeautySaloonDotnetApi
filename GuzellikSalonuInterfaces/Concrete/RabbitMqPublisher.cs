using GuzellikSalonuInterfaces.Abstract;
using GuzellikSalonuInterfaces.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces.Concrete
{
    public class RabbitMqPublisher
    {
        private readonly RabbitMqClientService _rabbitMqClientsService;

        public RabbitMqPublisher(RabbitMqClientService rabbitMqClientsService)
        {
            _rabbitMqClientsService = rabbitMqClientsService;
        }

        public bool Publish(MailRequest mailRequest)
        {
            try
            {
                var channel = _rabbitMqClientsService.Connect();
                var bodyString = JsonSerializer.Serialize(mailRequest.Body);
                var bodyByte = Encoding.UTF8.GetBytes(bodyString);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange:RabbitMqClientService.ExchangeName,
                    routingKey:RabbitMqClientService.ExchangeName,
                    mandatory:false,
                    basicProperties:properties,
                    body:bodyByte);
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
