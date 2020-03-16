using System;

namespace day2ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of steps: ");
            int step = int.Parse(Console.ReadLine());
            Stairs(step);
        }

        static void Stairs(int steps)
        {
             string stair = "#";  
            for (int i = 0; i < steps; i++)
            {
                Console.WriteLine(stair.PadLeft(steps));
                stair = stair + "#";
            }
        }
    }
}
