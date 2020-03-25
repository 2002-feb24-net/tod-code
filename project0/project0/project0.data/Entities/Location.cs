using System;
using System.Collections.Generic;

namespace Project0.data.Entities
{
    public partial class Location
    {
        public Location()
        {
            Customer = new HashSet<Customer>();
        }

        public string Name { get; set; }
        public int Storenum { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
