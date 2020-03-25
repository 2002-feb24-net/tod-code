using System;
using System.Collections.Generic;
using System.Text;

namespace project0.logic
{
    
        public class CustomerList
        {
            public List<Customers> patronList = new List<Customers>();

            public void AddCustomer(string name, string address, string phone, int? storeNum)
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

            public override string ToString()
            {
                string customerString = "";
                for (int i = 0; i < patronList.Count; i++)
                {
                    customerString = customerString + i + ". " + patronList[i].ToString() + "\n";
                }

                return customerString;
            }


        }

}
