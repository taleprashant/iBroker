using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBroker.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
        public string FlatNo { get; set; }
        public string Society { get; set; }
        public string Landmark { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string AddressOther { get; set; }
        public bool IsBroker { get; set; }

        public bool ValidateCustomerInfo(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName) && string.IsNullOrEmpty(customer.LastName) && string.IsNullOrEmpty(customer.PhoneNo1)
                && string.IsNullOrEmpty(customer.PhoneNo2))
            {
                return false;
            }

            return true;
        }
    }
}
