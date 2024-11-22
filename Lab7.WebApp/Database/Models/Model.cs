using System;
using System.Collections.Generic;

namespace Lab7.WebApp.Database.Models
{
    public class Model
    {
        public Guid ModelCode { get; set; }
        public Guid ManufacturerCode { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string OtherModelDetails { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
