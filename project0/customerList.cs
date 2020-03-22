using System;
using System.Collections.Generic;

namespace restaurant
{
    public class CustomerList
    {
        public List<Customer> patronList = new List<Customer>();

        public void AddCustomer(string name, string address, string phone, int storeNum)
        {
            var addCustomer = new Customer(name, address, phone, storeNum);
            patronList.Add(addCustomer);

        }

        public override string ToString()
        {
            string customerString = "";
            for(int i = 0; i < patronList.Count; i++)
            {
                customerString = customerString + i + ". " + patronList[i].ToString() + "\n";
            }

            return customerString;
        }

        
    }

    
}
