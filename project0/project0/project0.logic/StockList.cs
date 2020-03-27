using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project0;

namespace Project0.logic
{
    public class StockList
    {
        public Dictionary<FoodType, double> Inventory { get; set; }

        public Dictionary<FoodType, double> Staging { get; set; }

        private double dishQuantity;

        public StockList()
        {
            Inventory = new Dictionary<FoodType, double>();
            Staging = new Dictionary<FoodType, double>();
            dishQuantity = .5;
        }
        public void Add(FoodType food, double quantity)
        {
            Inventory.Add(food, quantity);
            Staging.Add(food, quantity);
        }
        /// <summary>
        /// This subtracts quantities from known food categories until it reaches negative numbers, then
        /// returns false and resets the dictionary
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Subtract(MenuItem item)
        {
            if (Staging.ContainsKey(item.category) && Staging[item.category] >= dishQuantity)
            {
                Staging[item.category] -= dishQuantity;
                return true;
            }
            else if (Staging.ContainsKey(item.category) && Staging[item.category] < dishQuantity)
            {
                //Staging = Inventory.ToDictionary(entry => entry.Key, entry => entry.Value);
                Staging.Clear();
                foreach(var entry in Inventory)
                {
                    Staging.Add(entry.Key, entry.Value);
                }
                return false;
            }
            return true;
        }

        public bool TryKey(FoodType food, out double val)
        {
            return Inventory.TryGetValue(food, out val);
        }

        public void FinalizePurchase()
        {
            //Inventory = Staging.ToDictionary(entry => entry.Key, entry => entry.Value);
            Inventory.Clear();
            foreach (var entry in Staging)
            {
                Inventory.Add(entry.Key, entry.Value);
            }

        }

        public override string ToString()
        {
            string str = "";

            foreach (var item in Inventory)
            {
                str += item.Value + " lbs - " + item.Key + "\n";  
            }
            return str;
        }

        public void Clear()
        {
            Inventory.Clear();
            Staging.Clear();
        }
      
    }
}
