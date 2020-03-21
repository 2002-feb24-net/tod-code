// class is to handle console IO for entering items into file io and pullng up menu
// maybe add interface when multiple io consoles needed

using System;

namespace restaurant
{
    public class MenuConsole
    {
        public Menu storeMenu {get; set;}
        
        public MenuConsole()
        {
            storeMenu = new Menu(); 
        }

        public void MainMenu()
        {
            char command;
            do
            {
                Console.WriteLine("\na: Add Menu Item");
                Console.WriteLine("m: Display Entire Menu");
                Console.WriteLine("Please Enter Command:");
                command = Console.ReadLine()[0];  
                
                if(command == 'a')
                    AddMenuItemConsole();
                else if (command == 'm')
                    Console.WriteLine(storeMenu.ToString()); 
            }while(command != 'q'); 

        }


        public void AddMenuItemConsole()
        {
            Console.WriteLine("Enter name of food:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price of food:");
            bool tryPrice = true;
            double price = 0;
            do
            {
                try
                {
                    price = double.Parse(Console.ReadLine());
                    tryPrice = false;
                }
                catch
                {
                    Console.WriteLine("Please Enter number for food price:");
                }
            } while (tryPrice);
        
            Console.WriteLine("Enter Item type");
            bool tryFood = true;
            FoodType food = 0;
            do
            {
                
                try
                {
                    food = (FoodType)Enum.Parse(typeof(FoodType),Console.ReadLine());
                    tryFood = false;
                }
                catch
                {
                    Console.WriteLine("Please Enter Correct Item Type");
                }
            } while (tryFood);

            storeMenu.AddItem(name, price, food);
        }

    }
}