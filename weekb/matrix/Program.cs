using System;
using System.Collections.Generic;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] index = new int[2,2]
            {
                {2,3},
                {5,4}
            };
            Matrix test = new Matrix(2, index);
            Matrix test2 = new Matrix(2, index);
            Console.WriteLine(test.ToString());
            Matrix addMatrix = test + test2;
            Console.WriteLine(addMatrix.ToString());
            test2 = 3 * addMatrix; 
            Console.WriteLine(test2.ToString());
            Matrix multMatrix = addMatrix * 5;
            Console.WriteLine(multMatrix.ToString());
            multMatrix = -multMatrix;
            Console.WriteLine(multMatrix.ToString());
            multMatrix.transposition();
            Console.WriteLine(multMatrix.ToString());

            
        }
    }
}
