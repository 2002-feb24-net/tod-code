using System;

namespace subnumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String: ");
            string userString = Console.ReadLine();
            int subLength;
            do{
            Console.Write("Enter substing length: ");
            subLength = int.Parse(Console.ReadLine());} while(subLength > userString.Length);
            WriteSubstrings(subLength, userString);

        }
        static void WriteSubstrings(int subLength, string userString)
        {
            for(int i = 0; i < (userString.Length - subLength + 1); i++)
            {
                Console.WriteLine(userString.Substring(i,subLength));
            }

        }

    }
}
