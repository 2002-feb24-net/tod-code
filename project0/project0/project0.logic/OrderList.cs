using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.logic
{

    /// <summary>
    /// List of orders of customers
    /// </summary>
    public class OrderList
    {
        public List<Order> receipts = new List<Order>();

        public int Count()
        {
            return receipts.Count;
        }

        public void AddOrder(Order ordered)
        {
            receipts.Add(ordered);
        }

        public void AddOrder(Customers orderer, DateTime localDate, List<MenuItem> menuOrder)
        {
            Order custOrder = new Order(orderer, localDate, menuOrder);
            receipts.Add(custOrder);
            
        }
        public override string ToString()
        {
            string receiptStr = "";
            for (int i = 0; i < receipts.Count; i++)
            {
                receiptStr = receiptStr + i + ". " + receipts[i].ToString();
            }
            return receiptStr;
        }


    }
}
