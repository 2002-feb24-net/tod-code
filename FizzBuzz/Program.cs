using System;

//Tod Jones: Count fizz and buzz and Fizzbuzz to 1000
//number of divisible by 3, 5, or both
//#Fizzbuzz is 66
//#Fizz is 267
//#buzz is 134

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int fizz = 0;
            int buzz = 0;
            int fizzbuzz = 0;

            for (int i = 1; i <= 1000; i++ )
            {
            if (i % 5 == 0 && i % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
                fizzbuzz++;
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
                fizz++;
            }
            else if (i % 5 == 0)
            {
                buzz++;
                Console.WriteLine("Buzz");
            }
            else
                Console.WriteLine(i);

            }
            Console.WriteLine ($"Number of fizzbuzz is {fizzbuzz}");
            Console.WriteLine($"Number of fizz is {fizz}");
            Console.WriteLine($"Number of buzz is {buzz}");
        }
    }
}
