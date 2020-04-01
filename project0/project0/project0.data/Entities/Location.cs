using System;
using System.Collections.Generic;

namespace Project0.data.Entities
{
    public partial class Location
    {
        /// <summary>
        /// communicates with location menu
        /// </summary>
        public Location()
        {
            Customer = new HashSet<Customer>();
            Inventory = new HashSet<Inventory>();
        }

        public string Name { get; set; }
        public int Storenum { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
