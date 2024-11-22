using System;
using System.Collections.Generic;

namespace Lab7.WebApp.Database.Models
{
    public class Mechanic
    {
        public Guid MechanicId { get; set; }
        public string MechanicName { get; set; }
        public string OtherMechanicDetails { get; set; }

        public ICollection<ServiceBooking> ServiceBookings { get; set; } = new List<ServiceBooking>();
        public ICollection<MechanicOnService> MechanicsOnServices { get; set; } = new List<MechanicOnService>();
    }
}
