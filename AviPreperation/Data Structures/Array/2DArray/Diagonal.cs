using System;
using System.Collections.Generic;
using System.Linq;

//Given a matrix of M x N elements(M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.



//Example:

//Input:
//[
// [ 1, 2, 3 ],
// [ 4, 5, 6 ],
// [ 7, 8, 9 ]
//]

//Output:  [1,2,4,7,5,3,6,8,9]

//Explanation:

 

//Note:

//The total number of elements of the given matrix will not exceed 10,000.

public class DiagonalOrderClass
{
    // Time complexity - O(mn)
    // Space Complexity - O(n)
    public int[] FindDiagonalOrder(int[][] matrix)
    {
        if (matrix.Length == 0)
            return new int[0];

        //initialization of variables
        int r = 0;
        int c = 0;
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[] arr = new int[m * n];

        //for loop
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = matrix[r][c];
            //upward direction
            if ((r + c) % 2 == 0)
            {
                if (c == n - 1)//c=2
                    r++;
                else if (r == 0)
                    c++;
                else
                {
                    r--;
                    c++;
                }
            }

            else
            {
                if (r == m - 1)
                    c++;
                else if (c == 0)
                    r++;
                else
                {
                    c--;
                    r++;
                }
            }
        };
        return arr;
    }
}
public class DiagonalOrderMain
{
    static void Main()
    {
        var pIndex = new DiagonalOrderClass();
        int[][] Array = new int[3][];
        Array[0] = new int[] { 1, 2, 3 };
        Array[1] = new int[] { 4, 5, 6 };
        Array[2] = new int[] { 7, 8, 9 };
        //int[] Array = new int[] { -1, -1, -1, 0, 1, 1 };
        Console.WriteLine(pIndex.FindDiagonalOrder(Array));
        Console.ReadLine();
    }
}
