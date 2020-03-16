using System;

namespace day2ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string stair = "#";
            int padding = 8;  
            for (int i = 0; i < padding; i++)
            {
                Console.WriteLine(stair.PadLeft(padding));
                stair = stair + "#";
            }
        }
    }
}
