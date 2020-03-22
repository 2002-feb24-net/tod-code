//item class is for Chinese menu items 
//todo: getter setters for individual items
//put enum in seperate file
//Chinese names for items?

using System;

namespace restaurant
{

    public class MenuItem
    {
        public string item{get; set;}
        public double price{get; set;}
        public FoodType category{get; set;}

        public MenuItem(string name, double cost, FoodType cat)
        {
            item = name;
            price = cost;
            category = cat;
        }

        public override string ToString()
        {
            return item + "-" + price + "-" + category;

        }
    }
}