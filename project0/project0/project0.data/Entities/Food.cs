using System;
using System.Collections.Generic;

namespace Project0.data.Entities
{

    /// <summary>
    /// food communicates with food table
    /// </summary>
    public partial class Food
    {
        public Food()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Foodtype { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
