using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.logic
{
    /// <summary>
    /// menu of food items and a display string
    /// </summary>
    public class Menu
    {
        public List<MenuItem> displayMenu = new List<MenuItem>();

        public void AddItem(string name, double cost, FoodType cat)
        {
            MenuItem entry = new MenuItem(name, cost, cat);
            displayMenu.Add(entry);
        }

        /*public void Sort()
        {
            var sortedList = displayMenu
        .OrderByDescending(x => (int)(x.category))
        .ToList();
        }*/

        public override string ToString()
        {
            string menuString = "";
            int menuNumber = 0;
            List<MenuItem> orderedMenu = new List<MenuItem>();
            menuString += "Appetizers: \n";
            for (int i = 0; i < displayMenu.Count; i++)
            {
                
                if ((int)displayMenu[i].category == 0)
                {
                    menuNumber++;
                    menuString = menuString + (menuNumber) + ". " + displayMenu[i].ToString() + "\n";
                    orderedMenu.Add(displayMenu[i]); 
                }
            }
            menuString += "Beef: \n";
            for (int i = 0; i < displayMenu.Count; i++)
            {
                
                
                if ((int)displayMenu[i].category == 1)
                {
                    menuNumber++;
                    menuString = menuString + (menuNumber) + ". " + displayMenu[i].ToString() + "\n";
                    orderedMenu.Add(displayMenu[i]);
                }
            }
            menuString += "Pork: \n";
            for (int i = 0; i < displayMenu.Count; i++)
            {
                if ((int)displayMenu[i].category == 2)
                {
                    menuNumber++;
                    menuString = menuString + (menuNumber) + ". " + displayMenu[i].ToString() + "\n";
                    orderedMenu.Add(displayMenu[i]);
                }
            }
            menuString += "Chicken: \n";
            for (int i = 0; i < displayMenu.Count; i++)
            {
                
                if ((int)displayMenu[i].category == 3)
                {
                    menuNumber++;
                    menuString = menuString + (menuNumber) + ". " + displayMenu[i].ToString() + "\n";
                    orderedMenu.Add(displayMenu[i]);
                }
            }
            menuString += "Drinks: \n";
            for (int i = 0; i < displayMenu.Count; i++)
            {
                
                if ((int)displayMenu[i].category == 4)
                {
                    menuNumber++;
                    menuString = menuString + (menuNumber) + ". " + displayMenu[i].ToString() + "\n";
                    orderedMenu.Add(displayMenu[i]);
                }
            }

            menuString += "Desserts: \n";
            for (int i = 0; i < displayMenu.Count; i++)
            {
                if ((int)displayMenu[i].category == 5)
                {
                    menuNumber++;
                    menuString = menuString + (menuNumber) + ". " + displayMenu[i].ToString() + "\n";
                    orderedMenu.Add(displayMenu[i]);
                }
            }
            displayMenu = orderedMenu;
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
