using System;
using System.Collections.Generic;

namespace Project0.data.Entities
{
    /// <summary>
    /// communicates with food order table
    /// </summary>
    public partial class FoodOrder
    {
        public FoodOrder()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string Name { get; set; }
        public int Ordernum { get; set; }
        public DateTime Ordertime { get; set; }

        public virtual Customer NameNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
