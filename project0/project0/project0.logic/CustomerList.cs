using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.logic
{
    /// <summary>
    /// class is a custom list of customers
    /// </summary>

    public class CustomerList
    {
        public List<Customers> patronList = new List<Customers>();

        public void AddCustomer(string name, string address, string phone, int storeNum)
        {
            var addCustomer = new Customers(name, address, phone, storeNum);
            patronList.Add(addCustomer);

        }

        public int Count()
        {
            return patronList.Count;
        }

        public Customers ReturnCustomer(int customerIndex)  //rewrite as overloaded operator index
        {
            return patronList[customerIndex];
        }

        public int GetStoreNum(int customerIndex)
        {
            return patronList[customerIndex].storeNum;
        }

        public string StoreCustomerSting(int store)
        {
            int index = 0;
            string customerString = "";
            for (int i = 0; i < patronList.Count; i++)
            {
                if (patronList[i].storeNum == store)
                {
                    index++;
                    customerString = customerString + index + ". " + patronList[i].ToString() + "\n";
                }
            }

            return customerString;

        }
        public override string ToString()
        {
            string customerString = "";
            for (int i = 0; i < patronList.Count; i++)
            {
                customerString = customerString + i + ". " + patronList[i].ToString() + "\n";
            }

            return customerString;
        }

        public string SearchString(string search, int storeNum)
        {
            string customerString = "";
            for (int i = 0; i < patronList.Count; i++)
            {
                if (patronList[i].name.ToLower().Contains(search.ToLower()) && patronList[i].storeNum == storeNum)
                {
                    customerString = customerString + i + ". " + patronList[i].ToString() + "\n";
                }
            }

            return customerString;
        }
    }

}

