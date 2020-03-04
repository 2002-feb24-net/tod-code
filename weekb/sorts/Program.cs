using System;

namespace sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] unsort = {2,3,6,8,4,5,1,3,7,9,11,3,4,5};
            int[] sort = BubbleSort(unsort);
            //Console.WriteLine(sort.ToString());
            for(int i = 0; i < sort.Length; i++)
            {
                Console.WriteLine(sort[i]);
            }
        }

        static int [] BubbleSort(int[] unsorted)
        {
            bool swapped;
            int sortedIndex = 0;
            int temp;

            while(sortedIndex < unsorted.Length-1)
            {
                swapped = false;
                for (int i = sortedIndex; i < unsorted.Length-1; i++)
                {
                    if(unsorted[i]>unsorted[i+1])
                    {
                        temp = unsorted[i];
                        unsorted[i] = unsorted[i+1];
                        unsorted[i+1] = temp;
                        swapped = true;
                    }
                }
                if(swapped == false)
                    sortedIndex++;

            }
            return unsorted;
        }
    }
}
