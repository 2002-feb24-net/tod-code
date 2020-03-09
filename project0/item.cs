using System;

namespace restaurant
{

    class MenuItem
    {
        private string item;
        private double price;//getter, setter .00 digit max

        enum Type
        {
            appetizer,
            beef,
            pork,
            chicken,
            drinks,
            desserts
        }

        Type category;

        MenuItem(string name, double cost, Type cat)
        {
            item = name;
            price = cost;
            category = cat;
        }
    }
}