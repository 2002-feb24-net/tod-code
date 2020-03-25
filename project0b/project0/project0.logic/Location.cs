using System;
using System.Collections.Generic;
using System.Text;

namespace project0.logic
{
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
