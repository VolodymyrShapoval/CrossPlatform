using System;

namespace Lab7.WebApp.Database.Models
{
    public class MechanicOnService
    {
        public Guid MechanicId { get; set; }
        public Mechanic Mechanic { get; set; }
        public Guid SvcBookingId { get; set; }
        public ServiceBooking ServiceBooking { get; set; }
    }
}
