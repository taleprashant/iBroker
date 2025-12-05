using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class Broker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
