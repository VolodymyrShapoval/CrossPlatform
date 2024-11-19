﻿using System;
using System.Collections.Generic;

namespace Lab6.WebApp.Database.Models
{
    public class Mechanic
    {
        public Guid MechanicId { get; set; }
        public string MechanicName { get; set; }
        public string OtherMechanicDetails { get; set; }

        public ICollection<MechanicOnService> MechanicsOnServices { get; set; }
    }
}
