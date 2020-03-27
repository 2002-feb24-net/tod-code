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
        /// <summary>
        /// adds items to menu list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="cat"></param>
        public void AddItem(string name, double cost, FoodType cat)
        {
            MenuItem entry = new MenuItem(name, cost, cat);
            displayMenu.Add(entry);
        }

       /// <summary>
       /// to string override for menu
       /// </summary>
       /// <returns></returns>

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
        /// <summary>
        /// grabs a menu item
        /// </summary>
        /// <param name="itemNum"></param>
        /// <returns></returns>
        public MenuItem GetItemFromMenu(int itemNum)
        {
            return displayMenu[itemNum];
        }
        /// <summary>
        /// returns item count
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return displayMenu.Count;
        }






    }

}
