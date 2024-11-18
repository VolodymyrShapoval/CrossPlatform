namespace Lab6.WebApp.Database.Models
{
    public class Car
    {
        public string LicenceNumber { get; set; }
        public string ModelCode { get; set; }
        public string CustomerId { get; set; }
        public int CurrentMileage { get; set; }
        public double EngineSize { get; set; }
        public string OtherCarDetails { get; set; }

        public Model Model { get; set; }
        public Customer Customer { get; set; }
    }
}
