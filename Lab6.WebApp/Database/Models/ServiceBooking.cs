using System.Collections.Generic;
using System;

namespace Lab6.WebApp.Database.Models
{
    public class ServiceBooking
    {
        public Guid SvcBookingId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid LicenceNumber { get; set; }
        public Car Car { get; set; }
        public bool PaymentReceivedYn { get; set; }
        public DateTime DatetimeOfService { get; set; }
        public DateTime DatetimeOfReceive { get; set; }
        public string OtherSvcBookingDetails { get; set; }

        public ICollection<Mechanic> Mechanics { get; set; } = new List<Mechanic>();
        public ICollection<MechanicOnService> MechanicsOnServices { get; set; } = new List<MechanicOnService>();
    }
}
