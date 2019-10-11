using System;
using System.Collections.Generic;
using System.Linq;

//Given a matrix of m x n elements(m rows, n columns), return all elements of the matrix in spiral order.

//Example 1:

//Input:
//[
// [ 1, 2, 3 ],
//[ 4, 5, 6 ],
//[ 7, 8, 9 ]
//]
//Output: [1,2,3,6,9,8,7,4,5]
//Example 2:

//Input:
//[
//  [1, 2, 3, 4],
//  [5, 6, 7, 8],
//  [9,10,11,12]
//]
//Output: [1,2,3,4,8,12,11,10,9,5,6,7]

//Input:
//[
// [1, 2, 3, 4, 5, 6],  
// [20,21,22,23,24,7],
// [19,32,33,34,25,8],
// [18,31,36,35,26,9],
// [17,30,29,28,27,10],
// [16,15,14,13,12,11]
//]
//Outpur: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36]

public class SpiralClass
{
    //Wrong but working for 4x3 and 3x3 matrices
    // should not use m-2 where we are restricting 
    public IList<int> SpiralOrder1(int[][] matrix)
    {
        if (matrix.Length == 0)
            return new List<int>();

        //initialization of variables
        int r = 0;
        int c = 0;
        int m = matrix.Length;
        int n = matrix[0].Length;
        IList<int> val = new List<int>();

        for (int i = 0; i <= m * n - 1; i++)
        {
            val.Add(matrix[r][c]);

            if ((r == 0 && c != n - 1) || (r == 1 && c < m - 1))
                c++;
            else if ((c == n - 1 && r < m - 1) || (r == m - 2))//should not use the number as it restricted to nx3matric only
                r++;
            else if (c != 0 && r == m - 1)
            {
                c--;
            }
            else if (c == 0 && r != 1)
            {
                r--;
            }

        }
        Console.WriteLine("r = " + r + " m =" + m);
        Console.WriteLine("c = " + c + " n =" + n);
        return val;
    }

    //Refere this Video for explanation
    //https://www.youtube.com/watch?v=TmweBVEL0I0 
    // Timw complwxity - O(mn)
    public IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix.Length == 0)
            return new List<int>();

        //initializing variables
        int fRow = 0;
        int fCol = 0;
        int lRow = matrix.Length - 1;
        int lCol = matrix[0].Length - 1;
        List<int> outPut = new List<int>();


        //looping through the rows and columns of outer matrix and then inner matices one by one
        while (fRow <= lRow && fCol <= lCol)
        {
            //top row: top side
            for (int i = fCol; i <= lCol; i++)
            {
                outPut.Add(matrix[fRow][i]);
            }
            fRow++;
            //right column: right side
            for (int i = fRow; i <= lRow; i++)
            {
                outPut.Add(matrix[i][lCol]);
            }
            lCol--;
            //last Row: bottom side
            if (fRow <= lRow)
            {
                for (int i = lCol; i >= fCol; i--)
                {
                    outPut.Add(matrix[lRow][i]);
                }
                lRow--;
            }
            //left col: left side
            if (fCol <= lCol)
            {
                for (int i = lRow; i >= fRow; i--)
                {
                    outPut.Add(matrix[i][fCol]);
                }
                fCol++;
            }
        }

        return outPut;
    }
}
public class DiagonalOrderMain
{
    static void Main()
    {
        var pIndex = new SpiralClass();
        int[][] Array = new int[3][];
        Array[0] = new int[] { 1, 2, 3 };
        Array[1] = new int[] { 4, 5, 6 };
        Array[2] = new int[] { 7, 8, 9 };
        //int[] Array = new int[] { -1, -1, -1, 0, 1, 1 };
        Console.WriteLine(pIndex.SpiralOrder(Array));
        Console.ReadLine();
    }
}
