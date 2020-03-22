//holds customer information
//todo: partial information, multiple constructors
//getters, setters for information

using System;


namespace restaurant
{
    public class Customer
    {

        public string name{get; set;}

        public string address{get; set;}

        public int storeNum{get; set;}

        public string phone{get; set;} //primary key

        public Customer(string name, string address, string phone, int storeNum)
        {
            this.name = name;
            this.address = address;
            this.storeNum = storeNum;
            this.phone = phone;

        }

        public override string ToString()
        {
            return name + ":" + address + ":" + phone + ":" + storeNum;
        }

        




    }
}