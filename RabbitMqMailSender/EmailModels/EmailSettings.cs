using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqMailSenderWorkerService.EmailModels
{
    public class EmailSettings
    {
        public string? Email { get; set; } = "halicarnassus33@gmail.com";
        public string? Password { get; set; } = "adwinbhtxnlfnvgd";
        public string? Host { get; set; } = "smtp.gmail.com";
        public string? DisplayName { get; set; }
        public int Port { get; set; } = 587;
    }
}
