namespace Lab6.WebApp.Database.Models
{
    public class MechanicOnService
    {
        public string MechanicId { get; set; }
        public string SvcBookingId { get; set; }

        public Mechanic Mechanic { get; set; }
        public ServiceBooking ServiceBooking { get; set; }
    }
}
