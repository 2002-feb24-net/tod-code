using System;
using System.Collections.Generic;
using System.Text;
using Project0.logic;
using Project0.data.Entities;
using System.Linq;


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

        public static void PopulateOrderList(OrderList popReceipts, CustomerList popCustomers, Menu popMenu)
        {
            using (var context = new restaurantContext())
            {
                //var customerList = context.
            }
        }
    }

}
