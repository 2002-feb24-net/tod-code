using System;

namespace PalindromeLib
{
    public class Palindrome : IPalindrome
    {
        public string input { get; set; }

        public Palindrome(string input)
        {
            this.input = input;
        }

       public bool IsPalindrome()
        {
            int j = input.Length - 1;
            for(int i = 0; i < j; i++)
            {
                if (input[i] != input[j])
                    return false;
                j--;
            }

            return true;
        }


    }
}
