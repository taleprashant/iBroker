using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class PropertySearch
    {
        public string ClientName { get; set; }
        public string ClientPhoneNo { get; set; }
        public string ClientEmail { get; set; }
        public string TransactionType { get; set; }
        public string PropertyType { get; set; }
        public string PropertySubType { get; set; }
        public List<string> Bedrooms { get; set; }
        public bool Active { get; set; }
        public int BudgetMin { get; set; }
        public int BudgetMax { get; set; }
        public List<string> FurnitureStatus { get; set; }
        public List<string> Locations { get; set; }
        public string RegistrationDateFrom { get; set; }
        public string RegistrationDateTo { get; set; }
        public string ReminderDateFrom { get; set; }
        public string ReminderDateTo { get; set; }
        public string Source { get; set; }
        public bool CommercialUse { get; set; }
        public List<string> AvailableForRent { get; set; }
        public List<string> Societies { get; set; }
        public int PropertyFloor { get; set; }
        public int PropertyAge { get; set; }
        public bool KeyWithUs { get; set; }
    }
}
