//holds customer information
//todo: partial information, multiple constructors
//getters, setters for information

using System;

namespace restaurant
{
    public class Customer
    {
        public string first{get; set;}
        public string last{get; set;}

        public string street{get; set;}

        public int storeNum{get; set;}

        public int phone{get; set;}

        public Customer(string first, string last, string street, int phone, int storeNum)
        {
            this.first = first;
            this.last = last;
            this.street = street;
            this.storeNum = storeNum;
            this.phone = phone;

        }

        




    }
}