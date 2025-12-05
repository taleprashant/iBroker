using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class Lease
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNo { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPAN { get; set; }
        public string OwnerAadharNo { get; set; }
        public string OwnerAddress { get; set; }

        public string TenantName { get; set; }
        public string TenantPhoneNo { get; set; }
        public string TenantEmail { get; set; }
        public string TenantPAN { get; set; }
        public string TenantAadharNo { get; set; }
        public string TenantAddress { get; set; }

        public string PropertyType { get; set; }
        public string PropertySubType { get; set; }
        public string PropertyUnitNo { get; set; }
        public string PropertySociety { get; set; }
        public string PropertyLandmark { get; set; }
        public string PropertySurveyNo { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyAddressOther { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyPincode { get; set; }
        public string PropertyBedrooms { get; set; }

        public string TokenNo { get; set; }
        public string GRNNo { get; set; }
        public int DurationInMonths { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int LockinPeriodInMonths { get; set; }
        public int NoticePeriodInMonths { get; set; }
        public string Escalation1 { get; set; }
        public string Escalation2 { get; set; }
        public string Escalation3 { get; set; }
        public string Remark { get; set; }
        public int Rent { get; set; }
        public int Deposit { get; set; }
        public string BrokerageDetail { get; set; }
        public string Source { get; set; }
        public bool IsActive { get; set; }
    }
}
