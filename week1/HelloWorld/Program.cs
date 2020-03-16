using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.OutputEncoding); 
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(Console.OutputEncoding);
            Console.WriteLine("老 周 达!");
        }
    }
}
