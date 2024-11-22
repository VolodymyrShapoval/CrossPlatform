using System;
using System.Collections.Generic;

namespace Lab7.WebApp.Database.Models
{
    public class Manufacturer
    {
        public Guid ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string OtherManufacturerDetails { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
