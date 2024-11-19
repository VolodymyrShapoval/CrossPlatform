using System;
using System.Collections.Generic;

namespace Lab6.WebApp.Database.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine_1 { get; set; }
        public string AddressLine_2 { get; set; }
        public string AddressLine_3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string OtherCustomerDetails { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
