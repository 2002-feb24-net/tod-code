using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.logic
{
    /// <summary>
    /// small class for restaurant locations
    /// </summary>
    public class Locations
    {
        public string cityState { get; set; }
        public int locNum { get; set; }

        public Locations(string cityState, int locNum)
        {
            this.cityState = cityState;
            this.locNum = locNum;
        }
    }
}
