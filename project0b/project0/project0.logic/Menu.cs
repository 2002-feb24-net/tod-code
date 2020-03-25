using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.logic
{
    public class Menu
    {
        public List<MenuItem> displayMenu = new List<MenuItem>();

        public void AddItem(string name, double cost, FoodType cat)
        {
            MenuItem entry = new MenuItem(name, cost, cat);
            displayMenu.Add(entry);
        }

        public override string ToString()
        {
            string menuString = "";
            for (int i = 0; i < displayMenu.Count; i++)
            {
                menuString = menuString + (i + 1) + ". " + displayMenu[i].ToString() + "\n";
            }
            return menuString;
        }

        public MenuItem GetItemFromMenu(int itemNum)
        {
            return displayMenu[itemNum];
        }

        public int Count()
        {
            return displayMenu.Count;
        }






    }

}
