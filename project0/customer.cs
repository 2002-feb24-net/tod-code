//holds customer information
//todo: partial information, multiple constructors
//getters, setters for information

using System;

namespace restaurant
{
    public class Customer
    {
        private string firstName;
        private string lastName;

        private string address;

        private int zipcode;

        private int phoneNumber;

        public Customer(string first, string last, string street, int phone, int zip)
        {
            firstName = first;
            lastName = last;
            address = street;
            zipcode = zip;
            phoneNumber = phone;

        }




    }
}