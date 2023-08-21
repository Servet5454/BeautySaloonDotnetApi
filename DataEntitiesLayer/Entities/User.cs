using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntitiesLayer.Entities
{
    public class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
            
        }


        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public bool IsOwner { get; set; }
        public string? Color { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }



    }
}
