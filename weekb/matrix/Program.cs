﻿using System;
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
                {3,4}
            };
            Matrix test = new Matrix(2, index);
            Matrix test2 = new Matrix(2, index);
            Console.WriteLine(test.toString());
            Matrix addMatrix = test + test2;
            Console.WriteLine(addMatrix.toString());
            test2 = 3 * addMatrix; 
            Console.WriteLine(test2.toString());
            Matrix multMatrix = addMatrix * 3;
        }
    }
}
