using System;
using System.Collections.Generic;

namespace Lab6.WebApp.Database.Models
{
    public class Car
    {
        public Guid LicenceNumber { get; set; }
        public Guid ModelCode { get; set; }
        public Model Model { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CurrentMileage { get; set; }
        public double EngineSize { get; set; }
        public string OtherCarDetails { get; set; }

        public ICollection<ServiceBooking> ServiceBookings { get; set; }
    }
}
