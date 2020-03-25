using System;
using System.Collections.Generic;
using System.Text;
using project0.logic;
using project0.data.Entities;
using System.Linq;


namespace project0
{
    public static class PopulateFromDB
    {

        public static bool PopulateMenu(Menu popMenu)
        {
            using (var context = new project0Context())
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
            using (var context = new project0Context())
            {
                var customList = context.Customerdb.ToList();
                for (int i = 0; i < customList.Count; i++)
                    popCustomer.AddCustomer(customList[i].Name, customList[i].Address,
                        customList[i].Phone, customList[i].Storenum);
            }
        }

        public static void PopulateOrderList(OrderList popReceipts, CustomerList popCustomers, Menu popMenu)
        {
            using (var context = new project0Context())
            {
                //var customerList = context.
            }
        }
    }
    
}
