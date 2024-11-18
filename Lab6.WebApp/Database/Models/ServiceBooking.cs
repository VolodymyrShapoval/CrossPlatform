using System.Collections.Generic;
using System;

namespace Lab6.WebApp.Database.Models
{
    public class ServiceBooking
    {
        public string SvcBookingId { get; set; }
        public string CustomerId { get; set; }
        public string LicenceNumber { get; set; }
        public bool PaymentReceivedYn { get; set; }
        public DateTime DatetimeOfService { get; set; }
        public DateTime DatetimeOfReceive { get; set; }
        public string OtherSvcBookingDetails { get; set; }

        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public ICollection<MechanicOnService> MechanicsOnServices { get; set; }
    }
}
