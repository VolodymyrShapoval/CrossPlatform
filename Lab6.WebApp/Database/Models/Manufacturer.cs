using System.Collections.Generic;

namespace Lab6.WebApp.Database.Models
{
    public class Manufacturer
    {
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string OtherManufacturerDetails { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
