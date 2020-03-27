using System;
using System.Collections.Generic;
using System.Text;
using Project0.logic;
using Project0.data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project0
{
    /// <summary>
    /// takes data from database and fills in logic classes
    /// </summary>
    public static class PopulateFromDB
    {

        public static List<Locations> PopulateLocations()
        {
            var returnList = new List<Locations>();
            using (var context = new restaurantContext())
            {
                var locationList = context.Location.ToList();
                for (int i = 0; i < locationList.Count; i++)
                {
                    var locale = new Locations(locationList[i].Name, locationList[i].Storenum);
                    returnList.Add(locale);

                }
            }
            return returnList;
        }
        public static void AddOrder(Order ordered, int orderCount)
        {
            var newOrder = new FoodOrder
            {
                Name = ordered.orderer.name,
                Ordernum = orderCount,
                Ordertime = DateTime.Now,
            };
            using (var context = new restaurantContext())
            {
                context.FoodOrder.Add(newOrder);
                context.SaveChanges();
            
                foreach(var element in ordered.menuOrder)
                {
                    var itemized = new OrderItem
                    {
                        Ordernum = orderCount,
                        Item = element.item
                    };
                    context.OrderItem.Add(itemized);
                    context.SaveChanges();
                }
            }
        }
        
        public static void AddCustomer(Customers patron)
        {
            var newCustomer = new Customer
            {
                Name = patron.name,
                Address = patron.address,
                Storenum = patron.storeNum,
                Phone = patron.phone
            };
            using (var context = new restaurantContext())
            {
                context.Customer.Add(newCustomer);
                context.SaveChanges();
            }

        }

        public static void AddMenuItem(MenuItem addItem)
        {
            var newFood = new Food
            {
                Name = addItem.item,
                Price = (decimal)addItem.price,
                Foodtype = addItem.category.ToString()
            };

            using (var context = new restaurantContext())
            {
                context.Food.Add(newFood);
                context.SaveChanges();
            }

        }
        public static bool PopulateMenu(Menu popMenu)
        {
            using (var context = new restaurantContext())
            {
                var menuList = context.Food.ToList();
                for (int i = 0; i < menuList.Count; i++)
                {
                    try
                    {
                        FoodType food = (FoodType)Enum.Parse(typeof(FoodType), menuList[i].Foodtype);
                        popMenu.AddItem(menuList[i].Name, (double)menuList[i].Price, food);
                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;
            }

        }

        public static void PopulateCustomerList(CustomerList popCustomer)
        {
            using (var context = new restaurantContext())
            {
                var customList = context.Customer.ToList();
                for (int i = 0; i < customList.Count; i++)
                    popCustomer.AddCustomer(customList[i].Name, customList[i].Address,
                        customList[i].Phone, customList[i].Storenum);
            }
        }

        public static void PopulateOrderList(OrderList popReceipts)
        {

            using (var context = new restaurantContext())
            {
                Customers tempCustomer;
                var receiptList = context.FoodOrder
                                         .Include(FoodOrder => FoodOrder.NameNavigation)
                                         .ToList();
                var foodDict = context.Food.ToDictionary(x => x.Name);
                var menuOrders = context.OrderItem.ToList();
                List<string> foodNames = new List<string>();
                
                for (int i = 0; i < receiptList.Count; i++)
                {
                    List<MenuItem> receiptItems = new List<MenuItem>();
                    tempCustomer = new Customers(receiptList[i].Name, receiptList[i].NameNavigation.Address,
                                                 receiptList[i].NameNavigation.Phone, receiptList[i].NameNavigation.Storenum);
                       int orderkey = receiptList[i].Ordernum;

                       foreach(var element in menuOrders)
                       {
                           if(element.Ordernum == orderkey)
                           {
                               foodDict.TryGetValue(element.Item, out Food foodItem); //might need a try catch in here
                               MenuItem tempItem =
                               new MenuItem(foodItem.Name, (double)foodItem.Price,
                               (FoodType)Enum.Parse(typeof(FoodType), foodItem.Foodtype));
                               receiptItems.Add(tempItem);
                           }
                       }
                       popReceipts.AddOrder(tempCustomer, receiptList[i].Ordertime, receiptItems);
                }
            }
        }
    }

}
