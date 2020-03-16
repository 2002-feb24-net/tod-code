using System;
using System.Collections.Generic;

namespace MinIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = {2, 1, 3, 5, 3, 2};
            int minval = firstDuplicate(arr1);
            Console.WriteLine(minval);
        }
    


static int firstDuplicate(int[] a) 
{
    int minIndex = -1;
    IDictionary<int, int> dict = new Dictionary<int, int>();
    for (int i = 0; i < (a.Length-1); i++)
        for (int j = i+1; j < a.Length; j++ )
        {
            if (a[i] == a[j])
                if(j < minIndex || minIndex == -1)
                {
                    minIndex = i;
                }
        }
            

    return a[minIndex];
}
    }
}