using System;
using System.Collections.Generic;
using System.Text;

namespace project0.logic
{
    public class OrderList
    {
        public List<Order> receipts = new List<Order>();

        public void AddOrder(Order ordered)
        {
            receipts.Add(ordered);
        }

        public override string ToString()
        {
            string receiptStr = "";
            for (int i = 0; i < receipts.Count; i++)
            {
                receiptStr = receiptStr + i + ". " + receiptStr[i].ToString();
            }
            return receiptStr;
        }


    }
}
