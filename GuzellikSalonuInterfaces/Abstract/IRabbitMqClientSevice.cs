using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace GuzellikSalonuInterfaces.Abstract
{
    public interface IRabbitMqClientSevice
    {
        public Task<IModel> Connect();
        public void  Dispose();
    }
}
