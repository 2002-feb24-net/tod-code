//Menu holds list of items
//todo: searchable, constructor, lunch specials?

using System;
using System.Collections.Generic;

namespace restaurant
{
    public class Menu
    {
        public List<MenuItem> displayMenu = new List<MenuItem>();

        public void AddItem(string name, double cost, FoodType cat)
        {
            MenuItem entry = new MenuItem(name, cost, cat);
            displayMenu.Add(entry);

        }

        
        
    }
}

