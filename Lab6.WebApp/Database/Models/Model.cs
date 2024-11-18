using System.Collections.Generic;

namespace Lab6.WebApp.Database.Models
{
    public class Model
    {
        public string ModelCode { get; set; }
        public string ManufacturerCode { get; set; }
        public string ModelName { get; set; }
        public string OtherModelDetails { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
