﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace Project0.logic
{

    /// <summary>
    /// Orders from customers
    /// </summary>
    public class Order
    {

        public DateTime localDate { get; set; }
        public Customers orderer { get; set; }
        public List<MenuItem> menuOrder { get; set; }

        /// <summary>
        /// don't use default constructor, just exists to get past compile error
        /// </summary>
        public Order()
        {
            localDate = DateTime.Now;
            menuOrder = new List<MenuItem>();
        }

        public Order(Customers orderer)
        {
            this.orderer = orderer;
            localDate = DateTime.Now;
            menuOrder = new List<MenuItem>();
        }

        public int Count()
        {
            return menuOrder.Count;
        }

        public Order(Customers orderer, List<MenuItem> menuOrder)
        {
            this.orderer = orderer;
            localDate = DateTime.Now;
            this.menuOrder = menuOrder;
        }

        public Order(Customers orderer, DateTime localDate, List<MenuItem> menuOrder)
        {
            this.orderer = orderer;
            this.localDate = localDate;
            this.menuOrder = menuOrder;

        }

        public void AddItem(MenuItem Item)  //candidate for interface
        {
            menuOrder.Add(Item);
        }

        public string DisplayOrder()
        {
            string display = "";
            for (int i = 0; i < menuOrder.Count; i++)
                display = display + (i + 1) + ". $" + menuOrder[i].price + " - " + menuOrder[i].item + "\n";
            return display;
        }

        public override string ToString()
        {
            return orderer.name + " -  " + localDate + "\n" + this.DisplayOrder();
        }

        public double CalculateTotal()
        {
            double total = 0;
            for (int i = 0; i < menuOrder.Count; i++)
                total += menuOrder[i].price;
            return total;
        }
    }

}
