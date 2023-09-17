using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqMailSenderWorkerService.EmailModels
{
    public class Costumer
    {
        public int Id { get; set; }
        public string? CostumerName { get; set; }
        public string? CostumerSurname { get; set; }
        public string? CostumerEmail { get; set; }
        public string? CostumerPhone { get; set; }
        public int Point { get; set; }
        public int Balance { get; set; }
    }
}
