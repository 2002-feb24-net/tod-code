// class is to handle console IO for entering items into file io and pullng up menu
// maybe add interface when multiple io consoles needed
// set cursor position


using System;

namespace restaurant
{
    public class MenuConsole
    {
        public Menu storeMenu {get; set;}
        public CustomerList storeCustomers {get; set;}
        private int storeNum;
        
        public MenuConsole()
        {
            storeMenu = new Menu();
            storeCustomers = new CustomerList();
            storeNum = 1;  //need to get this value
        }

        public void MainMenu()
        {
            char command;
            do
            {
                Console.WriteLine("\na: Add Menu Item");
                Console.WriteLine("m: Display Entire Menu");
                Console.WriteLine("c: Add a New Customer");
                Console.WriteLine("p: Print Customer List");
                Console.WriteLine("q: Quit Program");
                Console.WriteLine("Please Enter Command:");
                command = Console.ReadLine()[0];   //todo add try to catch error
                
                if(command == 'a')
                    AddMenuItemConsole();
                else if (command == 'm')
                {
                    Console.WriteLine(storeMenu.ToString());
                } 
                else if (command == 'c')
                {
                    AddCustomerConsole();
                }
                else if (command == 'p')
                {
                    Console.WriteLine(storeCustomers.ToString());
                }
            }while(command != 'q'); 
        }

        public void AddCustomerConsole()
        {
            Console.WriteLine("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            string phone = Console.ReadLine();

            storeCustomers.AddCustomer(name,address,phone,storeNum);
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
                    Console.WriteLine("Please enter valid number for price:");
                }
            } while (tryPrice);
        
            Console.WriteLine("Enter item type(appetizer, beef, pork, chicken, drink, dessert)");
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