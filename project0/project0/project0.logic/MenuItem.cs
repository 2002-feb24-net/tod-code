using System;
using project0;
using System.Linq;



namespace project0.logic
{
    public class MenuItem
    {
        public string item { get; set; }
        public double price { get; set; }
        public FoodType category { get; set; }


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
