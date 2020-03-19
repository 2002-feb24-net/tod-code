//holds customer information
//todo: partial information, multiple constructors
//getters, setters for information

using System;

namespace restaurant
{
    public class Customer
    {
        private string first;
        private string last;

        private string street;

        private int zip;

        private int phone;

        public Customer(string first, string last, string street, int phone, int zip)
        {
            this.first = first;
            this.last = last;
            this.street = street;
            this.zip = zip;
            this.phone = phone;

        }




    }
}