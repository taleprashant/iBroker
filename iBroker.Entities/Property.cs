
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        public string CreatedDate { get; set; }
        public string FlatNo { get; set; }
        public string Society { get; set; }
        public string Landmark { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string OtherAddress { get; set; }
        public string TransactionType { get; set; }
        public string PropertyType { get; set; }
        public string PropertySubType { get; set; }
        public string Bedrooms { get; set; }
        public int BathroomCount { get; set; }
        public int BalconyCount { get; set; }
        public int CoveredParkingCount { get; set; }
        public int OpenParkingCount { get; set; }
        public string FurnitureStatus { get; set; }
        public int TotalFloor { get; set; }
        public int PropertyFloor { get; set; }
        public int CarpetArea { get; set; }
        public string CarpetAreaUnit { get; set; }
        public int BuiltUpArea { get; set; }
        public string BuiltUpAreaUnit { get; set; }
        public int SuperBuiltUpArea { get; set; }
        public string SuperBuiltUpAreaUnit { get; set; }
        public int PropertyAgeYear { get; set; }
        public string AvailableRentFrom { get; set; }
        public string WillingRentFor { get; set; }
        public String ConstructionStatus { get; set; }
        public int PossessionInYears { get; set; }
        public string KeyPlacedAt { get; set; }
        public bool OnlinePublished { get; set; }
        public bool CommercialUse { get; set; }
        public bool BrokerageAgreed { get; set; }
        public string BrokerageDetail { get; set; }
        public string BalconyFacing { get; set; }
        public string MainDoorDirection { get; set; }

        public int RentPerMonth { get; set; }
        public int Deposit { get; set; }
        public int SellingPrice { get; set; }

        public bool IsActive { get; set; }
        public string Source { get; set; }
        public string Remark { get; set; }

    }
}
