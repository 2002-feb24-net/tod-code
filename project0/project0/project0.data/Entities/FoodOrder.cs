using System;
using System.Collections.Generic;

namespace project0.data.Entities
{
    public partial class FoodOrder
    {
        public FoodOrder()
        {
            OrderItem = new HashSet<OrderItem>();
            OrderItem1 = new HashSet<OrderItem1>();
        }

        public string Name { get; set; }
        public int Ordernum { get; set; }

        public virtual Customer NameNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<OrderItem1> OrderItem1 { get; set; }
    }
}
