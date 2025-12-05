using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class LeaseSearch
    {
        public bool Active { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNo { get; set; }
        public string TenantName { get; set; }
        public string TenantPhoneNo { get; set; }
        public string TokenNo { get; set; }
        public string GRNNo { get; set; }
        public string RegistrationDateFrom { get; set; }
        public string RegistrationDateTo { get; set; }
        public string LeaseEndDateFrom { get; set; }
        public string LeaseEndDateTo { get; set; }
        public List<string> Locations { get; set; }
        public List<string> Societies { get; set; }
    }
}
