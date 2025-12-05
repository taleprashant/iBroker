using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public string PropertyType { get; set; }
        public string PropertySubType { get; set; }
        public long MinBudget { get; set; }
        public long MaxBudget { get; set; }
        public int MinArea { get; set; }
        public int MaxArea { get; set; }
        public int FloorPreference { get; set; }
        public int WashroomCount { get; set; }
        public int BalconyCount { get; set; }
        public int LiftPresent { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Bedrooms { get; set; }
        public int ClientId { get; set; }
        public bool IsActive { get; set; }
        public string Source { get; set; }
        public string SocietyPreference { get; set; }
        public string Remark { get; set; }
        public string FurnitureStatus { get; set; }
        public string RequiredRentFor { get; set; }
        public string CreatedDate { get; set; }
    }
}
