using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace project0.logic
{
    public class Order
    {
        public DateTime localDate { get; set; }
        public Customer orderer { get; set; }
        public List<MenuItem> menuOrder { get; set; }


        public Order(Customer orderer)
        {
            this.orderer = orderer;
            localDate = DateTime.Now;
            menuOrder = new List<MenuItem>();
        }

        public void AddItem(MenuItem Item)  //candidate for interface
        {
            menuOrder.Add(Item);
        }

    }

}
