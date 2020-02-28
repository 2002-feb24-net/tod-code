using System;

namespace multiput
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Phrase:");
            string phrase = Console.ReadLine();
            string acronym = Acronym(phrase);
            Console.Write(acronym);
            
        }

        static string Acronym(string phrase)
        {
            string acronym = "";
            string word;
            string[] words = phrase.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                word = words[i];
                acronym += word[0];
            }
            return acronym;
        }
    }
}
