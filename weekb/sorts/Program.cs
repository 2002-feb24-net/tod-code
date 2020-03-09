using System;
using System.Collections.Generic;
namespace sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            int[] unsort = RandomArray(12);
            PrintArray(unsort);

            MergeSort(unsort);
            PrintArray(unsort);  
            //int[] sort = SelectionSort(unsort);
            //PrintArray(sort);
            //int[] sort2 = BubbleSort(unsort);
            //PrintArray(sort);
            
        }


        static void PrintArray(int[] Arr)
        {
            for(int i = 0; i < Arr.Length; i++)
            {
                Console.Write(Arr[i] + " ");
            }
            Console.Write("\n");
        }


    
    
        //imakes array of size n, populates with random number and returns array
        static int [] RandomArray(int n)
        {
            int[] randArray = new int[n];
            for(int i = 0; i < randArray.Length; i++)
            {
                Random rnd = new Random();
                int rndAnswer = rnd.Next(99);
                randArray[i] = rndAnswer;
            }
            return randArray;
        }

        static void MergeSort(int[] array)
        {
            // base case
            // if size is 0 or 1... stop here, it's already sorted.
            if (array.Length < 2)
            {
                return;
            }

            // recursive case
            int middle = array.Length / 2; // for example, if length 5, middle will be 2.

            int[] left = SubArray(array, 0, middle);
            int[] right = SubArray(array, middle, array.Length);

            MergeSort(left);
            MergeSort(right);

            // combine them.
            int l = 0;
            int r = 0;
            for (int i = 0; i < array.Length; i++)
            {
                // what if we've already finished either left or right? ...
                if (l >= left.Length)
                {
                    array[i] = right[r];
                    r++;
                }
                else if (r >= right.Length)
                {
                    array[i] = left[l];
                    l++;
                }
                // but if we haven't, then, we need to compare left and right.
                else if (left[l] <= right[r])
                {
                    array[i] = left[l];
                    l++;
                }
                else
                {
                    array[i] = right[r];
                    r++;
                }
            }
        }

        //          |-----|
        //        0  1  2  3
        // array [5, 8, 4, 8]
        // start 1, end 3
        // result should be [8, 4]
        static int[] SubArray(int[] array, int start, int end)
        {
            int length = end - start;
            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = array[start + i];
            }

            return result;
        }

    
        static int [] SelectionSort(int[] unsorted)
        {
            int temp;
            int minVal;
            int index = 0;
            for(int i=0; i < unsorted.Length - 1; i++)
            {
                minVal  = unsorted[i];
                index = i;
                for(int j=i+1; j < unsorted.Length; j++)
                {
                    if (minVal > unsorted[j])
                    {
                         index = j;
                         minVal = unsorted[j];
                    }
                }
                temp = unsorted[i];
                unsorted[i] = unsorted[index];
                unsorted[index] = temp;
            }
        
            return unsorted;
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
