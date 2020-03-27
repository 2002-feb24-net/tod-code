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
        /// <summary>
        /// count
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return receipts.Count;
        }
        /// <summary>
        /// adds order to list
        /// </summary>
        /// <param name="ordered"></param>
        public void AddOrder(Order ordered)
        {
            receipts.Add(ordered);
        }
        /// <summary>
        /// adds order based on customer data.
        /// </summary>
        /// <param name="orderer"></param>
        /// <param name="localDate"></param>
        /// <param name="menuOrder"></param>
        public void AddOrder(Customers orderer, DateTime localDate, List<MenuItem> menuOrder)
        {
            Order custOrder = new Order(orderer, localDate, menuOrder);
            receipts.Add(custOrder);
            
        }
        /// <summary>
        /// returns receipts of a single store.
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public string StoreReceipts(int store)
        {
            string receiptStr = "";
            for (int i = 0; i < receipts.Count; i++)
            {
                if(receipts[i].orderer.storeNum == store)
                    receiptStr = receiptStr + " " + receipts[i].ToString();
            }
            return receiptStr;
        }
        /// <summary>
        /// gets receipts based on name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetCustomerReceipts(string name)
        {
            string receiptStr = "";
            for (int i = 0; i < receipts.Count; i++)
            {
                if(receipts[i].orderer.name.ToLower().Contains(name.ToLower()))
                    receiptStr = receiptStr + " " + receipts[i].ToString();

            }
            return receiptStr;
        }
        /// <summary>
        /// to string method
        /// </summary>
        /// <returns></returns>
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
