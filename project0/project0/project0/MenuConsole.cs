using System;
using System.Collections.Generic;
using System.Text;
using Project0.logic;
using Project0.data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Project0
{
    /// <summary>
    /// Menu Consule is the main IO class for project0
    /// </summary>
    public class MenuConsole
    {
        public Menu storeMenu { get; set; }
        public CustomerList storeCustomers { get; set; }
        public OrderList receipts { get; set; }

        private int storeNum;
        public Customers orderer { get; set; }

        public List<Locations> locList { get; set; }

        public MenuConsole()
        {
            storeMenu = new Menu();
            storeCustomers = new CustomerList();
            receipts = new OrderList();
            orderer = null;
            PopulateFromDB.PopulateMenu(storeMenu);
            PopulateFromDB.PopulateCustomerList(storeCustomers);
            locList = PopulateFromDB.PopulateLocations();
            PopulateFromDB.PopulateOrderList(receipts);

        }
        public void IntroMenu()
        {
            
            bool validLoc = false;
            do
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Welcome to Zhou Mama's (周妈妈) Chinese Restaurant");
                for (int i = 0; i < locList.Count; i++)
                    Console.WriteLine($"{locList[i].locNum}. {locList[i].cityState}");
                Console.WriteLine("Please Enter Location Number:");
                try
                {
                    storeNum = int.Parse(Console.ReadLine());
                    storeNum--;
                    if (storeNum < locList.Count && storeNum > -1)
                        validLoc = true;
                    else
                    {
                        Console.WriteLine("Please enter an existing franchise number");
                        System.Threading.Thread.Sleep(3200);
                    }
                }
                catch
                {
                    Console.WriteLine("Please Enter a valid number");
                    System.Threading.Thread.Sleep(3200);
                }
            } while (!validLoc);
            MainMenu();
        }
        public void MainMenu()
        {

            char command;
            do
            {
                Console.WriteLine($"Welcome to Zhou Mama at {locList[storeNum].cityState}");
                Console.WriteLine("\na: Add Menu Item");
                Console.WriteLine("m: Display Entire Menu");
                Console.WriteLine("c: Add a New Customer");
                Console.WriteLine("p: Print Customer List for store Location");
                Console.WriteLine("o: Order for Customer");
                Console.WriteLine("r: Print Receipts for Store");
                Console.WriteLine("i: Go back to Location Menu");
                Console.WriteLine("q: Quit Program");
                Console.WriteLine("Please Enter Command:");
                try
                {
                    command = Console.ReadLine()[0];
                }
                catch
                {
                    Console.WriteLine("Please Enter valid input");
                    command = 'f';
                }
                if (command == 'a')
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
                    Console.WriteLine(storeCustomers.StoreCustomerSting(storeNum));
                }
                else if (command == 'o')
                {
                    OrderforCustomer();
                }
                else if (command == 'r')
                {

                    Console.WriteLine(receipts.Count());
                    Console.WriteLine(receipts.ToString());
                }
                else if (command == 'i')
                {
                    IntroMenu();
                    break;
                }
            } while (command != 'q');
        }

        public void OrderforCustomer()
        {
            Order customerOrder;
            int customNumber;
            do 
            {
                Console.Clear();
                Console.WriteLine("Search for customer");
                string search = Console.ReadLine();
                Console.WriteLine(storeCustomers.SearchString(search, storeNum));
                Console.WriteLine("Enter number of customer or -1 to search again");
                try
                {
                    customNumber = int.Parse(Console.ReadLine());
                }
                catch
                {
                    customNumber = -1;
                }

                }while (customNumber == -1);
                orderer = storeCustomers.ReturnCustomer(customNumber);
                customerOrder = new Order(orderer);
                int itemNum = 0;
                do
                {
                
                Console.WriteLine(storeMenu.ToString());
                Console.WriteLine(orderer.name);
                Console.WriteLine("Choose Menu Item by Number, -1 to quit");
                    try
                    {
                        itemNum = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Not a number. Please try again");
                    }
                Console.Clear();
                if (itemNum > 0 && itemNum < storeMenu.Count() + 1)
                        customerOrder.AddItem(storeMenu.GetItemFromMenu(itemNum - 1));
                    else
                        Console.WriteLine("Not an item on the Menu");

                    Console.WriteLine("Current Order: ");
                    Console.WriteLine(customerOrder.DisplayOrder());
                    Console.WriteLine(customerOrder.CalculateTotal() + " total");
                } while (itemNum != -1);
            
        }

        public void AddCustomerConsole()
        {
            Console.WriteLine("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            string phone = Console.ReadLine();

            storeCustomers.AddCustomer(name, address, phone, storeNum+1);
            orderer = new Customers(name, address, phone, (storeNum+1));
            PopulateFromDB.AddCustomer(orderer);


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
                    food = (FoodType)Enum.Parse(typeof(FoodType), Console.ReadLine());
                    tryFood = false;
                }
                catch
                {
                    Console.WriteLine("Please enter correct item type");
                }
            } while (tryFood);
            storeMenu.AddItem(name, price, food);
            var newItem = new MenuItem(name, price, food);
            PopulateFromDB.AddMenuItem(newItem);
        }

    }
}
