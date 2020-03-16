using System;

namespace day2ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter intial number: ");
            int step = int.Parse(Console.ReadLine());
            while(step != 1)
            {
                if (step % 2 != 0)
                {
                    step = step * 3 + 1;
                }
                else
                {
                    step /= 2;
                }
            Console.WriteLine(step);
            }
        }
    }
}

    