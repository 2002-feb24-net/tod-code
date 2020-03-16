using System;

namespace ArrayModifier
{
    class Program
    {
        // accept input from user, list of numbers separated by spaces
        // interpret that as an int array
        // print the array's values back to the user
        // ask the user for some operation
        // print the array's new values to the user.
        static void Main(string[] args)
        {
            string input = GetInput();
            int[] array = InterpretStringAsArray(input);
            PrintArray(array);
            Menu(array);
        }

        static void PrintArray(int[] a)
        {
            for(int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");
                Console.WriteLine(" ");

        }

        static int[] InterpretStringAsArray(string str)
        {
            string[] stringArr = str.Split(' ');
            int[] intArr = new int[stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
            {
                intArr[i] = int.Parse(stringArr[i]);
            }
            return intArr;
        }

        // any method is going to have
        // 1. a name
        // 2. a return value: either nothing (void), or some type e.g. int
            // what result does the method need to send back to the code that uses this method.
        // 3. a list of parameters (maybe empty)
            // does the method need any input from the code that uses it to do its job.
        static string GetInput()
        {
            Console.Write("Enter list of numbers: ");
            string input = Console.ReadLine();
            return input;
        }

        static int Add(int a, int b)
        {
            int result = a + b;
            return result;
            // you use "return" to send the return value back to the
            // code that calls this method.
        }

        static void Menu(int[] arr)
        {   
            char command = ' ';
            Console.Write("Enter Command:");
            do
            {
                command = (char)Console.Read();
                if(command == 'a'|| command == 'A')
                {
                    Console.WriteLine(AddArray(arr));
                    Console.Write("Enter Command:");
                }
                else if(command == 'r' || command == 'R')
                {
                    arr = ReverseArray(arr);
                    PrintArray(arr);
                    Console.Write("Enter Command:");
                }
                else if(command == 'b' || command == 'B')
                {
                    BackwardsArray(arr);
                    PrintArray(arr);
                    Console.Write("Enter Command:");
                }
                


            }while(command != 'q' && command != 'Q');

        }
        static int AddArray(int[] arr)
        {
            int size = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                size += arr[i];
            }

            return size;
        }

        static int[] ReverseArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= -1;
            }
            return arr;
        }

        static void BackwardsArray(int[] arr)
        {
             Array.Reverse(arr, 0, arr.Length);
        } 
    }
}
