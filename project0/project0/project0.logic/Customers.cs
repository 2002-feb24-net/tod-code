using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.logic
{
    public class Customers
    {
        public string name { get; set; }
        public string address { get; set; }
        public int storeNum { get; set; }
        public string phone { get; set; }

        public Customers(string name, string address, string phone, int storeNum)
        {
            this.name = name;
            this.address = address;
            this.storeNum = storeNum;
            this.phone = phone;

        }

        public Customers(Customers copyC)
        {
            this.name = copyC.name;
            this.address = copyC.address;
            this.storeNum = copyC.storeNum;
            this.phone = copyC.phone;
        }

        public override string ToString()
        {
            return name + ":" + address + ":" + phone + ":" + storeNum;
        }
    }
}
