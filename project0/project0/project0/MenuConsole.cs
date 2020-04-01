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

        public StockList storeInventory { get; set; }

        /// <summary>
        /// constructor, pulls info from database
        /// </summary>
        public MenuConsole()
        {
            storeMenu = new Menu();
            storeCustomers = new CustomerList();
            receipts = new OrderList();
            orderer = null;
            storeInventory = new StockList();
            PopulateFromDB.PopulateMenu(storeMenu);
            PopulateFromDB.PopulateCustomerList(storeCustomers);
            locList = PopulateFromDB.PopulateLocations();
            PopulateFromDB.PopulateOrderList(receipts);
        }

        /// <summary>
        /// introduction and location menu for console
        /// </summary>
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
                    
                    if ((storeNum-1) < locList.Count && (storeNum-1) > -1) //need -1 for compatibility with array
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
        /// <summary>
        /// Main Menu for console with loop
        /// </summary>
        public void MainMenu()
        {
            storeInventory.Clear();
            PopulateFromDB.PopulateInventory(storeNum, storeInventory);
            char command;
            do
            {
                Console.WriteLine($"Welcome to Zhou Mama at {locList[(storeNum-1)].cityState}");
                Console.WriteLine("\na: Add Menu Item");
                Console.WriteLine("m: Display Entire Menu");
                Console.WriteLine("c: Add a New Customer");
                Console.WriteLine("p: Print Customer List for store Location");
                Console.WriteLine("o: Order for Customer");
                Console.WriteLine("r: Print Receipts for Store");
                Console.WriteLine("s: Search for Customer Receipts");
                //Console.WriteLine("l: Restock Larder");
                Console.WriteLine("n: Check Inventory");
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
                {
                    AddMenuItemConsole();
                }
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
                else if (command == 's')
                {
                    SearchReceipts();
                }

                else if (command == 'r')
                {

                    Console.WriteLine(receipts.StoreReceipts(storeNum));
                }
                else if (command == 'i')
                {
                    IntroMenu();
                    break;
                }
                else if (command == 'n')
                {
                    PrintInventory();
                }
                /*else if (command == 'l')
                {
                    Restock();
                }*/
            } while (command != 'q');
        }
/*
        public void Restock()
        {
            PrintInventory();
            Console.WriteLine("What Meat would you like to restock?");
            string cat = Console.ReadLine();
            Console.WriteLine("Add quantity");
            try
            {
                double quant = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not a valid quantity");
            }
        }*/

        /// <summary>
        /// Prints inventory of restaurant
        /// </summary>
        public void PrintInventory()
        {
            Console.Clear();            
            Console.WriteLine(storeInventory.ToString());

        }

        /// <summary>
        /// Searchs customer orders
        /// </summary>
        public void SearchReceipts()
        {
            Console.Clear();
            Console.WriteLine("Search for customer");
            string search = Console.ReadLine();
            Console.WriteLine(receipts.GetCustomerReceipts(search));
        }
        /// <summary>
        /// makes customer order, checks larder
        /// </summary>

        public void OrderforCustomer()
        {
            Order customerOrder = new Order();
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


                if (customNumber > -1 && 
                    customNumber <= storeCustomers.Count() && 
                    storeCustomers.GetStoreNum(customNumber) == storeNum)
                {
                    orderer = storeCustomers.ReturnCustomer(customNumber);
                    customerOrder = new Order(orderer);
                }
                else
                {
                    Console.WriteLine("Not a customer of this store");
                    System.Threading.Thread.Sleep(3200);
                    customNumber = -1;
                }
            } while (customNumber == -1);
            int itemNum = 0;
            do
            {
                
                Console.WriteLine(storeMenu.ToString());
                Console.WriteLine(orderer.name);
                Console.WriteLine("Choose Menu Item by Number, -1 to quit, 0 to finalize");
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
                {
                    if (storeInventory.Subtract(storeMenu.GetItemFromMenu(itemNum - 1)))
                        customerOrder.AddItem(storeMenu.GetItemFromMenu(itemNum - 1));
                    else
                    {
                        Console.WriteLine("Sorry. We are out of enough to complete your order");
                        System.Threading.Thread.Sleep(3200);
                        itemNum = -1;
                        
                    }
                }
                else if (itemNum != 0 && itemNum != -1)
                {
                    Console.WriteLine("Not an item on the Menu");
                }
                Console.WriteLine("Current Order: ");
                Console.WriteLine(customerOrder.DisplayOrder());
                Console.WriteLine("$" + customerOrder.CalculateTotal() + " total");
                
                if(itemNum == 0 && customerOrder.Count() > 0)
                {
                    itemNum = -1;
                    receipts.AddOrder(customerOrder);
                    storeInventory.FinalizePurchase();
                    PopulateFromDB.ModifyInventory(storeNum, storeInventory);
                    PopulateFromDB.AddOrder(customerOrder, receipts.Count());
                }
            } while (itemNum != -1);   
        }
        /// <summary>
        /// Adds customer to store database
        /// </summary>
        public void AddCustomerConsole()
        {
            const int strlength = 20;
            Console.WriteLine("Enter Customer Name: ");
            string name = Console.ReadLine();
            name = name.Length > strlength ? name : name.Substring(0, strlength);
            Console.WriteLine("Enter address: ");
            string address = Console.ReadLine();
            address = address.Length > strlength ? address : address.Substring(0, strlength);
            Console.WriteLine("Enter Phone Number: ");
            string phone = Console.ReadLine();
            address = address.Length > strlength ? address : address.Substring(0, strlength);
            storeCustomers.AddCustomer(name, address, phone, storeNum);
            orderer = new Customers(name, address, phone, (storeNum));
            PopulateFromDB.AddCustomer(orderer);


        }
        /// <summary>
        /// adds a new menu item
        /// </summary>
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
