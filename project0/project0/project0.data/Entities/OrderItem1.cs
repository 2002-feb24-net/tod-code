using System;
using System.Collections.Generic;

namespace project0.data.Entities
{
    public partial class OrderItem1
    {
        public int Ordernum { get; set; }
        public int Id { get; set; }

        public virtual Food IdNavigation { get; set; }
        public virtual FoodOrder OrdernumNavigation { get; set; }
    }
}
