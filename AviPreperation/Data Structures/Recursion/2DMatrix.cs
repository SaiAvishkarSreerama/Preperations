using System;
using System.Collections.Generic;
using System.Text;
/*
 * Search a 2D Matrix II
* Solution
* Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
* 
* Integers in each row are sorted in ascending from left to right.
* Integers in each column are sorted in ascending from top to bottom.
* Example:
* 
* Consider the following matrix:
* 
* [
*   [1,   4,  7, 11, 15],
*   [2,   5,  8, 12, 19],
*   [3,   6,  9, 16, 22],
*   [10, 13, 14, 17, 24],
*   [18, 21, 23, 26, 30]
* ]
* Given target = 5, return true.
* 
* Given target = 20, return false.
 */
namespace AviPreperation.Data_Structures.Recursion
{
    // TimeComplexity -O(m+n)
    //spceComplexity - O(1)
    public class _2DMatrixSolution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0)
                return false;
            int r = 0;
            int c = matrix.GetLength(1) - 1;

            while (r <= matrix.GetLength(0) - 1 && c >= 0)
            {
                if (target == matrix[r, c])
                    return true;
                else if (target < matrix[r, c])
                    c--;
                else
                    r++;
            }

            return false;
        }
    }
}
