using System;

namespace reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string:");
            string input = Console.ReadLine();
            string reversi = "";
            for(int i = 0; i < input.Length; i++)
            {
                reversi += input[(input.Length - i - 1)];
            }
            Console.WriteLine(reversi);
            
        }
    }
}
