using System;
using System.Collections.Generic;
using System.Linq;


namespace project0.data.Entities
{
    public partial class Food
    {
        public Food()
        {
            OrderItem = new HashSet<OrderItem>();
            OrderItem1 = new HashSet<OrderItem1>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Foodtype { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<OrderItem1> OrderItem1 { get; set; }
    }
}
