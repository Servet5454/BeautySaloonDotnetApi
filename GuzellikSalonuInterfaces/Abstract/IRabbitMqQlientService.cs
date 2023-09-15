using GuzellikSalonuInterfaces.Email;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellikSalonuInterfaces.Abstract
{
    public interface IRabbitMqQlientService
    {
        public IModel Connect();
        public void Dispose();
        public bool Publish(MailRequest mailRequest);
    }
}
