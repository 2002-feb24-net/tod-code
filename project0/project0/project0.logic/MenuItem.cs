﻿using System;
using Project0;
using System.Linq;



namespace Project0.logic
{

    /// <summary>
    /// Food items and the category they belong into
    /// </summary>
    public class MenuItem
    {
        public string item { get; set; }
        public double price { get; set; }
        public FoodType category { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="cat"></param>

        public MenuItem(string name, double cost, FoodType cat)
        {
            item = name;
            price = cost;
            category = cat;

        }
        /// <summary>
        /// string override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return item + "-" + price;


        }
    }
}
