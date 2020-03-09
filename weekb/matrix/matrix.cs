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

        public int col;

        public int row;
        public int[,] matrixArray;
        public Matrix(int n)
        {
            size = n;
            col = n;
            row = n;
            matrixArray = new int[n,n];
        }

        public Matrix(int column, int rows)
        {
            size = column;
            col = column;
            row = rows;
            matrixArray = new int[col,row];
        }

        public Matrix(int n, int[,] fill)
        {
            size = n;
            col = n;
            row = n;
            matrixArray = new int[col,row];
            for (int i = 0; i < col; i++)
                for(int j = 0; j < row; j++)
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
            for(int i=0; i < a.col; i++)
                for(int j=0; j < a.row; j++)
                     addMatrix.SetElement(i,j,a.GetElement(i,j)+b.GetElement(i,j));
            return addMatrix;
        }

        public static Matrix operator* (int n, Matrix a)
        {
            Matrix multMatrix = new Matrix(a.col, a.row);
            for(int i=0; i < a.col; i++)
                for(int j=0; j < a.row; j++)
                    multMatrix.SetElement(i,j,a.GetElement(i,j)*n);
            return multMatrix;
        }

        public static Matrix operator* (Matrix a, int n)
        {
            Matrix multMatrix = new Matrix(a.col, a.row);
            for(int i=0; i < a.col; i++)
                for(int j=0; j < a.row; j++)
                    multMatrix.SetElement(i,j,a.GetElement(i,j)*n);
            return multMatrix;
        }

        public static Matrix operator- (Matrix a)
        {
            return -1 * a;
        }

        public Matrix transposition()
        {
            int[,] transpose = new int[row, col];
                for(int i = 0; i < col;i++)
                    for(int j = 0; j < row; j++)
                        transpose[j,i] = matrixArray[i,j];
            matrixArray = transpose;
            return this;
        }
        public override string ToString()
        {
            string strMatrix = "";
            for(int i = 0; i < col; i++)
            {
                strMatrix = strMatrix + "|" + matrixArray[i,0]; 
                for(int j = 1; j < row; j++)
                    strMatrix = strMatrix + "," + matrixArray[i,j];
                strMatrix = strMatrix + "|" + "\n";
            }
            return strMatrix;
        }
    }

    

}