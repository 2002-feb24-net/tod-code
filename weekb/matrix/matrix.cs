//Tod Jones
//Matrix Class 
//includes addition and scalar multiplication
//using operator overloading

using System;
using System.Collections.Generic;

namespace matrix
{
    
    public class Matrix
    {
        public int size;
        public int[,] matrixArray;
        public Matrix(int n)
        {
            size = n;
            matrixArray = new int[n,n];
        }

        public Matrix(int n, int[,] fill)
        {
            size = n;
            matrixArray = new int[n,n];
            for (int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
            {
                matrixArray[i,j] = fill[i,j];
            }
        }

        public int GetElement(int x, int y)
        {
            return matrixArray[x,y];
        }

        public void SetElement(int x, int y, int n)
        {
            matrixArray[x,y]=n;
        }
        public static Matrix operator+ (Matrix a, Matrix b)
        {
            if(a.size != b.size)
                return a;
            Matrix addMatrix = new Matrix(a.size);
            for(int i=0; i < a.size; i++)
                for(int j=0; j < a.size; j++)
                     addMatrix.SetElement(i,j,a.GetElement(i,j)+b.GetElement(i,j));
            return addMatrix;
        }

        public static Matrix operator* (int n, Matrix a)
        {
            Matrix multMatrix = new Matrix(a.size);
            for(int i=0; i < a.size; i++)
                for(int j=0; j < a.size; j++)
                    multMatrix.SetElement(i,j,a.GetElement(i,j)*n);
            return multMatrix;
        }

        public static Matrix operator* (Matrix a, int n)
        {
            Matrix multMatrix = new Matrix(a.size);
            for(int i=0; i < a.size; i++)
                for(int j=0; j < a.size; j++)
                    multMatrix.SetElement(i,j,a.GetElement(i,j)*n);
            return multMatrix;
        }

        public string toString()
        {
            string strMatrix = "";
            for(int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                    strMatrix = strMatrix + "," + matrixArray[i,j];
                
            

            return strMatrix;
        }
    }

    

}