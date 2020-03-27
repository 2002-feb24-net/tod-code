﻿using System;
using System.Collections.Generic;

namespace Project0.data.Entities
{
    public partial class Inventory
    {
        public int Storenum { get; set; }
        public string Item { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Location StorenumNavigation { get; set; }
    }
}
