/*
Tod Jones
This program takes a multiline input
and outputs the acronym in uppercase to console

*/
using System;

namespace multiput
{
    class Program
    {
        // main does basic IO 
        static void Main(string[] args)
        {
            Console.Write("Enter Phrase:");
            string phrase = Console.ReadLine();
            string acronym = Acronym(phrase);
            Console.Write(acronym);
            
        }
//Acronym splits phrase into string array of words, then 
//returns new string with first element of each word in uppercase
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
            return acronym.ToUpper();
        }
    }
}
