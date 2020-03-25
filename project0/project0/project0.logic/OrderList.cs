﻿using System;
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
